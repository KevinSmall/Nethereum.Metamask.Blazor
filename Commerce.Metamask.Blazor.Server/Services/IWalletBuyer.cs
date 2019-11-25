using System.Threading.Tasks;
using Commerce.Buyer.Lib;

namespace Commerce.Metamask.Blazor.Server.Services
{
    public interface IWalletBuyer
    {
        BuyerUILib Lib { get; }

        Task<ulong> GetLatestBlockNumber();
    }
}