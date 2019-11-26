using Microsoft.AspNetCore.Components;
using Nethereum.Web3;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;
using Commerce.Metamask.Blazor.Server.Services;
using Microsoft.Extensions.Logging;
using Commerce.Buyer.Lib.Services;

namespace Commerce.Metamask.Blazor.Server
{
    public class CommerceBuyerBase : ComponentBase
    {
        public string DebugText01 { get; set; }
        public string DebugText02 { get; set; }

        public SettingsModel Settings { get; set; }
        public string BuyerPoNumber { get; set; }
        public string AdditionalMessage { get; set; }

        [Inject]
        public IWalletBuyer WalletBuyer { get; set; }

        private int _renderCounter;

        protected override void OnInitialized()
        {
            //TODO fix this
            Settings = new SettingsModel
            {
                BlockchainUrl = "Not available",
                WalletBuyerAddress = "Not available",
                BusinessPartnersContractAddress = "Not available", // not defined until OnInitializedAsync()
                AccountWithEther = "Not available",
                AccountWithEtherKey = "Not available"
            };

            BuyerPoNumber = "PO_20191107171001691"; // PO created by blazor wallet
            //BuyerPoNumber = "PO_201910171603403952520"; // PO created by SAP wallet
            AdditionalMessage = "start";
            _renderCounter = 0;
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            _renderCounter++;

            if (firstRender)
            {
                //DebugText01 = "CommerceBuyerBase OnAfterRenderAsync First";
                if (!WalletBuyer.IsInitialized)
                {
                    await WalletBuyer.InitializeAsync();
                }
                string s = WalletBuyer.Lib.Wallet.Info.PoMainAddress;
                //var blockn = await WalletBuyer.GetLatestBlockNumberAsync();
                //AdditionalMessage = blockn.ToString();
                DebugText01 = $"CommerceBuyerBase OnAfterRenderAsync FirstRender Wallet Buyer Initialized {s}";
            }
            else
            {
                DebugText02 = $"CommerceBuyerBase OnAfterRenderAsync More {_renderCounter}";
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //    // Get the business partner storage address from PO main 
                //    var web3 = new Web3(Settings.BlockchainUrl);
                //    var wbs = new WalletBuyerService(web3, Settings.WalletBuyerAddress);
                //    var poMainAddress = await wbs.PoMainQueryAsync();
                //    var poms = new PoMainService(web3, poMainAddress);
                //    Settings.BusinessPartnersContractAddress = await poms.BusinessPartnerStorageQueryAsync();

                //    // Get block number that was valid at app startup            
                //    Settings.BlockNumberValidAtAppStartup = (ulong)(await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
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
