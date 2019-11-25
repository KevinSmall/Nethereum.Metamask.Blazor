using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;

namespace Commerce.Metamask.Blazor.Server.Components
{
    public class CreateBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public SettingsModel Settings { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }

        public PoCreateModel PoCreateModel { get; set; }
        public TransactionReceipt ReceiptForCreateRequest { get; set; }
        public string AdditionalMessage { get; set; }
        public bool IsBusy { get; private set; }

        //[Inject]
        //public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            //PoCreateModel = new PoCreateModel
            //{
            //    BuyerPurchaseOrderNumber = BuyerPoNumber,
            //    SellerSysId = "SoylentCorporation",
            //    BuyerProductId = "BHT-1101 this needs updated",
            //    Currency = "DAI",
            //    CurrencyAddress = "0x7bbd0d72e59ede7f2a65abde9539aa006682c741",
            //    TotalQuantity = 4,
            //    TotalValue = 10
            //};
            AdditionalMessage = "none";
            base.OnInitialized();
        }

        protected async Task CreatePo()
        {
            IsBusy = true;
            ReceiptForCreateRequest = null;

            try
            {
                //var web3 = new Web3(new Account(Settings.AccountWithEtherKey), Settings.BlockchainUrl);
                //var wbs = new WalletBuyerService(web3, Settings.WalletBuyerAddress);

                //// Check PO number is new
                //var poMainAddress = await wbs.PoMainQueryAsync();
                //var poms = new PoMainService(web3, poMainAddress);
                //var buyerSysId = await wbs.SystemIdQueryAsync();
                //var buyerSysIdAsString = ConversionUtils.ConvertBytes32ArrayToString(buyerSysId);
                //var buyerPoNumberAsBytes = ConversionUtils.ConvertStringToBytes32Array(BuyerPoNumber);
                //var po = await poms.GetPoByBuyerPoNumberQueryAsync(buyerSysId, buyerPoNumberAsBytes);

                //if (po != null && po.Po != null && po.Po.EthPurchaseOrderNumber != 0)
                //{
                //    // PO already exists    
                //    AdditionalMessage = $"Buyer PO {BuyerPoNumber} already exists as Eth PO {po.Po.EthPurchaseOrderNumber}";
                //}
                //else
                //{
                //    // Create new PO
                //    PoCreateModel.BuyerPurchaseOrderNumber = BuyerPoNumber; // refresh model value from parent value
                //    Po newPo = CreatePoDefn
                //    (
                //        buyerSysId: buyerSysIdAsString,
                //        buyerPurchaseOrderNumber: PoCreateModel.BuyerPurchaseOrderNumber,
                //        sellerSysId: PoCreateModel.SellerSysId,
                //        buyerProductId: PoCreateModel.BuyerProductId,
                //        currency: PoCreateModel.Currency,
                //        currencyAddress: PoCreateModel.CurrencyAddress,
                //        totalQuantity: PoCreateModel.TotalQuantity,
                //        totalValue: PoCreateModel.TotalValue
                //    );
                //    AdditionalMessage = $"Creation request sent for Buyer PO {PoCreateModel.BuyerPurchaseOrderNumber}";
                //    ReceiptForCreateRequest = await wbs.CreatePurchaseOrderRequestAndWaitForReceiptAsync(newPo);
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

        //private Po CreatePoDefn(
        //    string buyerSysId,
        //    string buyerPurchaseOrderNumber,
        //    string sellerSysId,
        //    string buyerProductId,
        //    string currency,
        //    string currencyAddress,
        //    uint totalQuantity,
        //    uint totalValue)
        //{
        //    return new Po()
        //    {
        //        //EthPurchaseOrderNumber;                               // leave initial, filled by PoMain
        //        BuyerSysId = buyerSysId,
        //        BuyerPurchaseOrderNumber = buyerPurchaseOrderNumber,
        //        BuyerViewVendorId = string.Empty,                       // leave initial, filled by PoMain
        //        SellerSysId = sellerSysId,
        //        SellerSalesOrderNumber = string.Empty,                  // leave initial, filled by PoMain
        //        SellerViewCustomerId = string.Empty,                    // leave initial, filled by PoMain
        //        BuyerProductId = buyerProductId,
        //        SellerProductId = string.Empty,                         // leave initial, filled by PoMain
        //        Currency = currency,
        //        CurrencyAddress = currencyAddress,
        //        TotalQuantity = totalQuantity,
        //        TotalValue = totalValue,
        //        //OpenInvoiceQuantity; leave initial, filled by PoMain
        //        //OpenInvoiceValue; leave initial, filled by PoMain
        //        //PoStatus; leave initial, filled by PoMain
        //        //WiProcessStatus; leave initial, filled by PoMain
        //    };
        //}
    }
}
