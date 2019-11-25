using System.Threading.Tasks;
using Commerce.Buyer.Lib.Models;
using Nethereum.RPC.Eth.DTOs;

namespace Commerce.Buyer.Lib.Services
{
    /// <summary>
    /// Get, Create or Cancel a Purchase Order
    /// </summary>
    public interface IPurchaseOrder
    {
        /// <summary>
        /// Create PO and wait for receipt. Throws if tx not possible (e.g. no Ether)
        /// </summary>
        /// <returns>Transaction receipt, null if PO already exists</returns>
        Task<TransactionReceipt> CreatePoAndWaitForReceiptAsync(PoCreateModel poCreateModel);

        /// <summary>
        /// Returns PO, or null if PO not found
        /// </summary>
        /// <param name="buyerPoNumber">Buyer system PO number</param>        
        Task<PoModel> GetPo(string buyerPoNumber);

        /// <summary>
        /// Returns PO, or null if PO not found
        /// </summary>
        /// <param name="ethPoNumber">Global Ethereum PO number</param>        
        Task<PoModel> GetPo(ulong ethPoNumber);

        /// <summary>
        /// Request a PO be cancelled and wait for receipt. Throws if tx not possible (e.g. no Ether)
        /// </summary>
        /// <param name="buyerPoNumber">Buyer system PO number</param>
        /// <returns>Transaction receipt, null if PO does not exist</returns>
        Task<TransactionReceipt> RequestPoCancelAndWaitForReceiptAsync(string buyerPoNumber);

        /// <summary>
        /// Request a PO be cancelled and wait for receipt. Throws if tx not possible (e.g. no Ether).
        /// </summary>
        /// <param name="ethPoNumber">Global Ethereum PO number</param>
        /// <returns>Transaction receipt, null if PO does not exist</returns>
        Task<TransactionReceipt> RequestPoCancelAndWaitForReceiptAsync(ulong ethPoNumber);
    }
}