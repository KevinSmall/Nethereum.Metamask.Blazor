using Commerce.Buyer.Lib;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Threading.Tasks;

namespace Commerce.Metamask.Blazor.Server.Services
{
    public class WalletBuyer : IWalletBuyer
    {
        public BuyerUILib Lib { get; private set; }

        private readonly WalletBuyerConfig _options;
        private readonly ILogger<WalletBuyer> _logger;
        private Web3 _web3;
        private MetamaskInterceptor _metamaskInterceptor;

        public WalletBuyer(
            ILogger<WalletBuyer> logger,
            IOptions<WalletBuyerConfig> options,
            MetamaskInterceptor metamaskInterceptor)
        {
            _logger = logger;
            _options = options.Value;
            _metamaskInterceptor = metamaskInterceptor;

            try
            {
                SetupWalletBuyer();
                _logger.LogInformation("Created wallet buyer service ok.");
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Failed to create wallet buyer service: {ex.Message}");
            }
        }

        public async Task<ulong> GetLatestBlockNumber()
        {
            if (_web3 == null)
            {
                try
                {
                    SetupWalletBuyer();
                    _logger.LogInformation("Created buyer contracts service ok.");
                }
                catch (System.Exception ex)
                {
                    _logger.LogError($"Failed to create buyer contracts service: {ex.Message}");
                    throw new System.NullReferenceException("Buyer contracts web3 is not setup");
                }
            }
            var blockHex = await _web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            return (ulong)blockHex.Value;
        }

        private void SetupWalletBuyer()
        {
            // TODO get metmask and use it here
            _logger.LogError($"Intentionally not setting up Wallet Buyer (to prevent exception)");
            return;

            _web3 = new Nethereum.Web3.Web3();
            _web3.Client.OverridingRequestInterceptor = _metamaskInterceptor;
            //var block = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(1));
            ////BlockHash = block.BlockHash;

            //_web3 = null; // new Web3(new Account(_options.EtherPrivateKey), _options.BlockchainUrl);
            //_web3 = new Web3(new Account(_options.EtherPrivateKey), _options.BlockchainUrl);
            // TODO could pass in the _logger ILogger transformed to an ILog here:
            Lib = new BuyerUILib(this._web3, _options.WalletBuyerContractAddress);
            Lib.InitializeAsync().GetAwaiter().GetResult();
        }
    }
}
