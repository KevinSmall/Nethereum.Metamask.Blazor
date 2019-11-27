using Commerce.Buyer.Lib.Models;
using Commerce.Metamask.Blazor.Server.Services;
using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Threading.Tasks;

namespace Commerce.Metamask.Blazor.Server.Components
{
    public class CreateBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }

        public PoCreateModel PoCreateModel { get; set; }
        public TransactionReceipt ReceiptForCreateRequest { get; set; }
        public string AdditionalMessage { get; set; }
        public bool IsBusy { get; private set; }

        [Inject]
        public IWalletBuyer WalletBuyer { get; set; }

        protected override void OnInitialized()
        {
            PoCreateModel = new PoCreateModel
            {
                BuyerPurchaseOrderNumber = BuyerPoNumber,
                SellerSysId = "SoylentCorporation",
                BuyerProductId = "BHT-1101",
                Currency = "DAI",
                CurrencyAddress = "0x7bbd0d72e59ede7f2a65abde9539aa006682c741",
                TotalQuantity = 4,
                TotalValue = 10
            };
            AdditionalMessage = "none";
            base.OnInitialized();
        }

        protected async Task CreatePo()
        {
            IsBusy = true;
            ReceiptForCreateRequest = null;

            try
            {
                // Check PO number is new
                var po = await WalletBuyer.Lib.PurchaseOrder.GetPoAsync(BuyerPoNumber).ConfigureAwait(false);
                if (po != null && po.EthPurchaseOrderNumber != 0)
                {
                    // PO already exists    
                    AdditionalMessage = $"Buyer PO {BuyerPoNumber} already exists as Eth PO {po.EthPurchaseOrderNumber}";
                }
                else
                {
                    // Create new PO
                    PoCreateModel.BuyerPurchaseOrderNumber = BuyerPoNumber; // refresh model value from parent value
                    AdditionalMessage = $"Creation request being sent for Buyer PO {PoCreateModel.BuyerPurchaseOrderNumber}";
                    ReceiptForCreateRequest = await WalletBuyer.Lib.PurchaseOrder.CreatePoAndWaitForReceiptAsync(PoCreateModel).ConfigureAwait(false);
                }
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
