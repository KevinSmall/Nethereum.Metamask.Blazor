using System.ComponentModel.DataAnnotations;

namespace Commerce.Buyer.Lib.Models
{
    public class WalletModel
    {     
        public string BlockchainName { get; set; }

        [StringLength(42)]
        public string WalletBuyerAddress { get; set; }

        [StringLength(42)]
        public string PoMainAddress { get; set; }

        [StringLength(32)]
        public string BuyerSysId { get; set; }
        
        [StringLength(32)]
        public string BuyerSysDesc { get; set; }

        public byte[] BuyerSysIdAsBytes { get; set; }
    }
}
