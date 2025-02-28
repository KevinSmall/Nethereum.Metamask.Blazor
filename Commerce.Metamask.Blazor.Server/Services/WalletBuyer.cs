﻿using Commerce.Buyer.Lib;
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
        public bool IsInitialized { get; private set; }

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

            _web3 = new Web3();
            Lib = new BuyerUILib(this._web3, _options.WalletBuyerContractAddress);
        }

        public async Task InitializeAsync()
        {
            try
            {
                // Web3                
                _web3.Client.OverridingRequestInterceptor = _metamaskInterceptor;

                // UI Library
                // TODO could pass in the _logger ILogger transformed to an ILog here:                
                await Lib.InitializeAsync();
                _logger.LogInformation("Created wallet buyer service ok.");
                IsInitialized = true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Failed to create wallet buyer service: {ex.Message}");
                IsInitialized = false;
            }
        }
    }
}
