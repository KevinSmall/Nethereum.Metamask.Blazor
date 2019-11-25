using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Commerce.Metamask.Blazor.Server.Models
{
    public class EventLogModel
    {
        // Key
        public BigInteger BlockNumber { get; set; }

        public string TransactionHash { get; set; }

        public BigInteger TransactionIndex { get; set; }

        public BigInteger LogIndex { get; set; }

        // Data
        public string EventName { get; set; }

        public DateTime Timestamp { get; set; }

        [StringLength(8)]
        public string BlockDate { get; set; }

        [StringLength(6)]
        public string BlockTime { get; set; }

        public PoModel Po { get; set; }
    }
}
