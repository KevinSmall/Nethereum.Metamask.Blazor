using Microsoft.AspNetCore.Components;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;

namespace Commerce.Metamask.Blazor.Server.Components
{
    public class DisplayBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public SettingsModel Settings { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }
                
        public PoModel PurchaseOrder { get; set; }
        public string AdditionalMessage { get; set; }
        public bool IsBusy { get; private set; }

        //[Inject]
        //public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            PurchaseOrder = new PoModel { };
            base.OnInitialized();
        }

        protected async Task DisplayPo()
        {
            IsBusy = true;
            try
            {
                //var web3 = new Web3(Settings.BlockchainUrl);
                //var wbs = new WalletBuyerService(web3, Settings.WalletBuyerAddress);

                //// Check PO number exists for the buyer source system id (which is retrieved from the buyer wallet)
                //var poMainAddress = await wbs.PoMainQueryAsync();
                //var poms = new PoMainService(web3, poMainAddress);
                //var buyerSysId = await wbs.SystemIdQueryAsync();
                //var buyerSysIdAsString = ConversionUtils.ConvertBytes32ArrayToString(buyerSysId);
                //var buyerPoNumberAsBytes = ConversionUtils.ConvertStringToBytes32Array(BuyerPoNumber);
                //var po = await poms.GetPoByBuyerPoNumberQueryAsync(buyerSysId, buyerPoNumberAsBytes);

                //if (po != null && po.Po != null && po.Po.EthPurchaseOrderNumber != 0)
                //{
                //    // PO exists    
                //    var retrievedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                //    AdditionalMessage = $"Buyer PO {BuyerPoNumber} retrieved at {retrievedAt}";
                //    PurchaseOrder = MapPoFields(po.Po);
                //}
                //else
                //{
                //    AdditionalMessage = $"Buyer PO {BuyerPoNumber} does not exist";
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

        //private PoModel MapPoFields(Po po)
        //{
        //    return new PoModel
        //    {
        //        EthPurchaseOrderNumber = po.EthPurchaseOrderNumber,
        //        BuyerSysId = po.BuyerSysId,
        //        BuyerPurchaseOrderNumber = po.BuyerPurchaseOrderNumber,
        //        SellerSysId = po.SellerSysId,
        //        SellerSalesOrderNumber = po.SellerSalesOrderNumber,
        //        BuyerProductId = po.BuyerProductId,
        //        Currency = po.Currency,
        //        CurrencyAddress = po.CurrencyAddress,
        //        TotalQuantity = po.TotalQuantity,
        //        TotalValue = po.TotalValue,
        //        OpenInvoiceQuantity = po.OpenInvoiceQuantity,
        //        OpenInvoiceValue = po.OpenInvoiceValue,
        //        PoStatusCode = po.PoStatus,
        //        PoStatus = GetStatusDescription(po.PoStatus),
        //        WiProcessStatus = po.WiProcessStatus
        //    };
        //}

        private string GetStatusDescription(byte poStatus)
        {
            string description = "Initial";
            if (poStatus == 1) description = "Purchase Order Created";
            else if (poStatus == 2) description = "Sales Order Received";
            else if (poStatus == 3) description = "Completed";
            else if (poStatus == 4) description = "Cancelled";
            return description;
        }
    }
}
