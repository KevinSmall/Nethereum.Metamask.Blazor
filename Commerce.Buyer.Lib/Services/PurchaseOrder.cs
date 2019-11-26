using Commerce.Buyer.Lib.Models;
using Common.Logging;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using PoBuyer = Commerce.Buyer.Lib.Contracts.WalletBuyer.ContractDefinition;
using PoMain = Commerce.Buyer.Lib.Contracts.PoMain.ContractDefinition;

namespace Commerce.Buyer.Lib.Services
{
    public class PurchaseOrder : IPurchaseOrder
    {
        private IWallet _wallet;
        private ILog _log;
        private IFieldMapper _mapper;

        public PurchaseOrder(IWallet wallet, IFieldMapper mapper, ILog log)
        {
            _wallet = wallet;
            _mapper = mapper;
            _log = log;
        }
                
        public async Task<PoModel> GetPoAsync(ulong ethPoNumber)
        {
            var po = (await _wallet.PoMainService.GetPoByEthPoNumberQueryAsync(ethPoNumber)
                .ConfigureAwait(false)).Po;
            if (po == null || po.EthPurchaseOrderNumber == 0)
            {
                return null;
            }
            else
            {
                return _mapper.MapFieldsPoToPoModel(po);
            }
        }
       
        public async Task<PoModel> GetPoAsync(string buyerPoNumber)
        {
            var buyerPoNumberAsBytes = ConversionUtils.ConvertStringToBytes32Array(buyerPoNumber);
            var po = (await _wallet.PoMainService.GetPoByBuyerPoNumberQueryAsync(_wallet.Info.BuyerSysIdAsBytes, buyerPoNumberAsBytes)
                .ConfigureAwait(false)).Po;
            if (po == null || po.EthPurchaseOrderNumber == 0)
            {
                return null;
            }
            else
            {
                return _mapper.MapFieldsPoToPoModel(po);
            }
        }
                
        public async Task<TransactionReceipt> RequestPoCancelAndWaitForReceiptAsync(ulong ethPoNumber)
        {
            // Check PO exists
            TransactionReceipt receipt = null;
            var po = await GetPoAsync(ethPoNumber);
            if (po == null)
            {
                _log?.Warn($"EthPO {ethPoNumber} not found on blockchain");
            }
            else
            {
                // Attempt cancellation
                receipt = await _wallet.BuyerService.CancelPurchaseOrderRequestAndWaitForReceiptAsync(po.EthPurchaseOrderNumber).ConfigureAwait(false);
                if (receipt.Status.Value == 0)
                {
                    _log?.Error($"Transaction {receipt.TransactionHash} failed");
                }
                else
                {
                    _log?.Info($"Request to cancel eth PO {ethPoNumber} successful in transaction {receipt.TransactionHash}");
                }                
            }
            return receipt;
        }

        public async Task<TransactionReceipt> RequestPoCancelAndWaitForReceiptAsync(string buyerPoNumber)
        {
            // Check PO exists
            TransactionReceipt receipt = null;
            var po = await GetPoAsync(buyerPoNumber);
            if (po == null)
            {
                _log?.Warn($"Buyer PO ({_wallet.Info.BuyerSysId}, {buyerPoNumber}) not found on blockchain");
            }
            else
            {
                receipt = await RequestPoCancelAndWaitForReceiptAsync(po.EthPurchaseOrderNumber).ConfigureAwait(false);
            }
            return receipt;
        }
                
        public async Task<TransactionReceipt> CreatePoAndWaitForReceiptAsync(PoCreateModel poCreateModel)
        {
            // Check PO exists
            TransactionReceipt receipt = null;
            var existingPo = await GetPoAsync(poCreateModel.BuyerPurchaseOrderNumber);
            if (existingPo == null)
            {
                // Ok to create new PO
                PoBuyer.Po newPo = _mapper.MapFieldsPoCreateModelToPo(_wallet.Info.BuyerSysId, poCreateModel);
                receipt = await _wallet.BuyerService.CreatePurchaseOrderRequestAndWaitForReceiptAsync(newPo);
            }
            else
            {
                _log?.Warn($"Attempt to create duplicate buyer PO ({_wallet.Info.BuyerSysId}, {poCreateModel.BuyerPurchaseOrderNumber})");
            }
            return receipt;
        }
    }
}
