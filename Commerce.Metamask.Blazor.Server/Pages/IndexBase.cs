using Commerce.Metamask.Blazor.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Commerce.Metamask.Blazor.Server
{
    public class IndexBase : ComponentBase
    {
        public string BuyerPoNumber { get; set; }
        public string AdditionalMessage { get; set; }

        [Inject]
        public IWalletBuyer WalletBuyer { get; set; }

        private int _renderCounter;

        protected override void OnInitialized()
        {
            BuyerPoNumber = "PO_20191107171001691"; // PO created by blazor wallet
            //BuyerPoNumber = "PO_201910171603403952520"; // PO created by SAP wallet
            AdditionalMessage = string.Empty;
            _renderCounter = 0;
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            _renderCounter++;

            if (firstRender)
            {
                if (!WalletBuyer.IsInitialized)
                {
                    await WalletBuyer.InitializeAsync();
                }             
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                // Init moved to OnAfterRenderAsync so that JavaScript interop works for Metamask service
            }
            catch (Exception ex)
            {

                AdditionalMessage = ex.Message;
            }
            finally
            {
                await base.OnInitializedAsync();
            }
        }

        public void GeneratePoNumber()
        {
            BuyerPoNumber = "PO_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        }
    }
}
