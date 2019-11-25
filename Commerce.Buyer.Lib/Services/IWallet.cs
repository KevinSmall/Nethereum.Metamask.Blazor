using System.Threading.Tasks;
using Commerce.Buyer.Lib.Contracts.PoMain;
using Commerce.Buyer.Lib.Contracts.WalletBuyer;
using Commerce.Buyer.Lib.Models;
using Nethereum.Web3;

namespace Commerce.Buyer.Lib.Services
{
    /// <summary>
    /// Provides chain information, buyer wallet contract access, web3 access
    /// </summary>
    public interface IWallet
    {
        /// <summary>
        /// Code generated access to the WalletBuyer contract
        /// </summary>
        WalletBuyerService BuyerService { get; }

        /// <summary>
        /// Information about the chain and wallet being used
        /// </summary>
        WalletModel Info { get; }

        /// <summary>
        /// Code generated access to the PoMain contract
        /// </summary>
        PoMainService PoMainService { get; }
        
        /// <summary>
        /// Access to the Nethereum Web3 used to create this wallet
        /// </summary>
        Web3 Web3 { get; }

        /// <summary>
        /// Wallet must be initialized before being used
        /// </summary>        
        Task InitializeAsync();
    }
}