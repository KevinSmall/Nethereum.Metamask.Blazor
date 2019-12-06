using Commerce.Buyer.Lib;
using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Threading.Tasks;

namespace Commerce.Buyer.PoBlazorComponents
{
    public class CancelBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public IBuyerUILib BuyerUILib { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }

        public TransactionReceipt ReceiptForCancelRequest { get; private set; }
        public string AdditionalMessage { get; private set; }
        public bool IsBusy { get; private set; }

        protected override void OnInitialized()
        {
            AdditionalMessage = "none";
            base.OnInitialized();
        }

        protected async Task CancelPo()
        {
            IsBusy = true;
            try
            {
                // Send cancellation request
                AdditionalMessage = $"Cancellation request is being sent for Buyer PO {BuyerPoNumber}";
                ReceiptForCancelRequest = await BuyerUILib.PurchaseOrder.RequestPoCancelAndWaitForReceiptAsync(BuyerPoNumber);
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
