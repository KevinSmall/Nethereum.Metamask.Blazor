using Commerce.Buyer.Lib.Services;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib
{
    public interface IBuyerUILib
    {
        IEventLogs EventLogs { get; }
        IPurchaseOrder PurchaseOrder { get; }
        IWallet Wallet { get; }

        Task InitializeAsync();
    }
}