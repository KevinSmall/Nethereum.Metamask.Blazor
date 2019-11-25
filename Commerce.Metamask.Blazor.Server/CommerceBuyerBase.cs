using Microsoft.AspNetCore.Components;
using Nethereum.Web3;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;

namespace Commerce.Metamask.Blazor.Server
{
    public class CommerceBuyerBase : ComponentBase
    {
        public SettingsModel Settings { get; set; }
        public string BuyerPoNumber { get; set; }
        public string AdditionalMessage { get; set; }

        //[Inject]
        //public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            Settings = new SettingsModel
            {
                BlockchainUrl = "https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c",
                WalletBuyerAddress = "0x3a61a411F11444768a6e8CCf9AE242180098bBF7",
                BusinessPartnersContractAddress = string.Empty, // not defined until OnInitializedAsync()
                AccountWithEther = "0x32A555F2328e85E489f9a5f03669DC820CE7EBe9",
                AccountWithEtherKey = "517311d936323b28ca55379280d3b307d354f35ae35b214c6349e9828e809adc"
            };

            BuyerPoNumber = "PO_20191107171001691"; // PO created by blazor wallet
            //BuyerPoNumber = "PO_201910171603403952520"; // PO created by SAP wallet

            base.OnInitialized();
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
