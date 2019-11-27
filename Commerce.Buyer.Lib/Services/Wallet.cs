using Commerce.Buyer.Lib.Contracts.BusinessPartnerStorage;
using Commerce.Buyer.Lib.Contracts.PoMain;
using Commerce.Buyer.Lib.Contracts.WalletBuyer;
using Commerce.Buyer.Lib.Models;
using Common.Logging;
using Nethereum.Web3;
using System;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib.Services
{
    public class Wallet : IWallet
    {
        public WalletModel Info { get; private set; }
        public WalletBuyerService BuyerService { get; private set; }
        public PoMainService PoMainService { get; private set; }
        public Web3 Web3 { get; private set; }

        private readonly ILog _log;
        private readonly string _walletBuyerAddress;
        private string _businessPartnersContractAddress;
        private BusinessPartnerStorageService _bpss;
        private bool _hasBeenInitialized;

        public Wallet(Web3 web3, string walletBuyerAddress, ILog log)
        {
            Web3 = web3 ?? throw new ArgumentNullException(nameof(web3));
            if (string.IsNullOrWhiteSpace(walletBuyerAddress))
            {
                throw new ArgumentException("Wallet buyer address must be specified", nameof(walletBuyerAddress));
            }
            _walletBuyerAddress = walletBuyerAddress;
            _log = log;
            BuyerService = new WalletBuyerService(Web3, _walletBuyerAddress);

            Info = new WalletModel();
        }

        public async Task InitializeAsync()
        {
            if (!_hasBeenInitialized)
            {
                // Chain
                var chainId = (ulong)(await Web3.Eth.ChainId.SendRequestAsync()).Value;
                Info.BlockchainName = Enum.GetName(typeof(Nethereum.Signer.Chain), chainId);

                // Addresses
                Info.WalletBuyerAddress = _walletBuyerAddress;
                Info.PoMainAddress = await BuyerService.PoMainQueryAsync();

                // Related services
                PoMainService = new PoMainService(Web3, Info.PoMainAddress);
                _businessPartnersContractAddress = await PoMainService.BusinessPartnerStorageQueryAsync();
                _bpss = new BusinessPartnerStorageService(Web3, _businessPartnersContractAddress);

                // Buyer Sys Id
                Info.BuyerSysIdAsBytes = await BuyerService.SystemIdQueryAsync();
                Info.BuyerSysId = ConversionUtils.ConvertBytes32ArrayToString(Info.BuyerSysIdAsBytes);
                Info.BuyerSysDesc = await _bpss.GetSystemDescriptionQueryAsync(Info.BuyerSysIdAsBytes);

                _hasBeenInitialized = true;
            }
        }
    }
}
