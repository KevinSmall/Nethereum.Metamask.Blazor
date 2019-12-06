using Commerce.Buyer.Lib;
using Commerce.Buyer.Lib.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Commerce.Buyer.PoBlazorComponents
{
    public class DisplayBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public IBuyerUILib BuyerUILib { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }

        public PoModel PurchaseOrder { get; set; }
        public string AdditionalMessage { get; set; }
        public bool IsBusy { get; private set; }

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
                var po = await BuyerUILib.PurchaseOrder.GetPoAsync(BuyerPoNumber).ConfigureAwait(false);
                if (po != null && po.EthPurchaseOrderNumber != 0)
                {
                    // PO exists    
                    var retrievedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    AdditionalMessage = $"Buyer PO {BuyerPoNumber} retrieved at {retrievedAt}";
                    PurchaseOrder = po;
                }
                else
                {
                    AdditionalMessage = $"Buyer PO {BuyerPoNumber} does not exist";
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
