using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;

namespace Commerce.Metamask.Blazor.Server.Components
{
    public class CancelBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public SettingsModel Settings { get; set; }
        
        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }
                
        public TransactionReceipt ReceiptForCancelRequest { get; private set; }
        public string AdditionalMessage { get; private set; }
        public bool IsBusy { get; private set; }              

        //[Inject]
        //public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            AdditionalMessage = "none";
            base.OnInitialized();
        }

        protected async Task CancelPo()
        {
            IsBusy = true;
            //ReceiptForCancelRequest = null;
            //var web3 = new Web3(new Account(Settings.AccountWithEtherKey), Settings.BlockchainUrl);
            //var wbs = new WalletBuyerService(web3, Settings.WalletBuyerAddress);

            try
            {
                //// Get PO Main service
                //var poMainAddress = await wbs.PoMainQueryAsync();
                //var poms = new PoMainService(web3, poMainAddress);

                //// Get the Eth PO number
                //var buyerSysId = await wbs.SystemIdQueryAsync();
                //var buyerPoNumberAsBytes = ConversionUtils.ConvertStringToBytes32Array(BuyerPoNumber);
                //var po = await poms.GetPoByBuyerPoNumberQueryAsync(buyerSysId, buyerPoNumberAsBytes);

                //if (po == null || po.Po == null || po.Po.EthPurchaseOrderNumber == 0)
                //{
                //    AdditionalMessage = $"Buyer Purchase order {BuyerPoNumber} not found";
                //}
                //else
                //{
                //    // Send cancellation request
                //    AdditionalMessage = $"Cancellation request sent for Eth PO {po.Po.EthPurchaseOrderNumber}, Buyer PO {BuyerPoNumber}";
                //    ReceiptForCancelRequest = await wbs.CancelPurchaseOrderRequestAndWaitForReceiptAsync(po.Po.EthPurchaseOrderNumber);
                //}
            }
            catch (Exception ex)
            {
                AdditionalMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
