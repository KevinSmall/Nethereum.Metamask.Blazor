using Commerce.Buyer.Lib.Services;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib
{
    /// <summary>
    /// Allows:
    ///   Purchase Order create, cancel, display.
    ///   Retrieval of PO event logs.
    ///   Retrieval of Wallet information.
    /// This is all tied to a single Buyer Wallet.
    /// </summary>
    public interface IBuyerUILib
    {
        IEventLogs EventLogs { get; }
        IPurchaseOrder PurchaseOrder { get; }
        IWallet Wallet { get; }

        Task InitializeAsync();
    }
}