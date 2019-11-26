using Commerce.Metamask.Blazor.Server.Models;
using Commerce.Metamask.Blazor.Server.Services;
using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Threading.Tasks;

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

        [Inject]
        public IWalletBuyer WalletBuyer { get; set; }

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
                ReceiptForCancelRequest = await WalletBuyer.Lib.PurchaseOrder.RequestPoCancelAndWaitForReceiptAsync(BuyerPoNumber);
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
