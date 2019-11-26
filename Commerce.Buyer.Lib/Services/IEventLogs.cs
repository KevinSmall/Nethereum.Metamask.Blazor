using System.Threading.Tasks;
using Commerce.Buyer.Lib.Models;

namespace Commerce.Buyer.Lib.Services
{
    /// <summary>
    /// Retrieves events logs for a PO
    /// </summary>
    public interface IEventLogs
    {
        /// <summary>
        /// Retrieves all event logs emitted by the buyer wallet, for a given PO.
        /// This is very fast (a few seconds) to get events even from entire chain, because events are indexed by PO.
        /// Omit startBlock and endBlock parameters to search entire chain.
        /// </summary>
        /// <param name="ethPoNumber">Ethereum Global PO number</param>
        /// <param name="startBlock">Optional start block for search, omit to use 0</param>
        /// <param name="endBlock">Optional end block for search, omit to use 0</param>
        /// <returns>Array of event logs, empty array if no events (also empty if passed a non-existing PO)</returns>
        Task<EventLogModel[]> GetEventLogsForPoAsync(ulong poNumber, ulong startBlock = 0, ulong endBlock = 0);

        /// <summary>
        /// Retrieves all event logs emitted by the buyer wallet, for a given PO.
        /// This is very fast (a few seconds) to get events even from entire chain, because events are indexed by PO.
        /// Omit startBlock and endBlock parameters to search entire chain.
        /// </summary>
        /// <param name="BuyerPoNumber">Buyer PO number</param>
        /// <param name="startBlock">Optional start block for search, omit to use 0</param>
        /// <param name="endBlock">Optional end block for search, omit to use latest block</param>
        /// <returns>Array of event logs, empty array if no events (also empty if passed a non-existing PO)</returns>
        Task<EventLogModel[]> GetEventLogsForPoAsync(string buyerPoNumber, ulong startBlock = 0, ulong endBlock = 0);

        /// <summary>
        /// Retrieves all event logs emitted by the buyer wallet, for ALL POs.
        /// This is not very fast (many minutes) to get events from entire chain.
        /// If you need events for just a few POs use method <see cref="IEventLogs.GetEventLogsForPoAsync(ulong, ulong, ulong)"/> instead.
        /// </summary>
        /// <param name="startBlock">Optional start block for search, omit to use 0</param>
        /// <param name="endBlock">Optional end block for search, omit to use latest block</param>
        /// <returns>Array of event logs, empty array if no events found</returns>
        Task<EventLogModel[]> GetEventLogsForAllPosAsync(ulong startBlock, ulong endBlock);

    }
}