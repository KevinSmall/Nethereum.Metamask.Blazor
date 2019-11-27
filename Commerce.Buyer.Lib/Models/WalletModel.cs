using System.ComponentModel.DataAnnotations;

namespace Commerce.Buyer.Lib.Models
{
    public class WalletModel
    {
        public string BlockchainName { get; set; } = string.Empty;

        [StringLength(42)]
        public string WalletBuyerAddress { get; set; } = string.Empty;

        [StringLength(42)]
        public string PoMainAddress { get; set; } = string.Empty;

        [StringLength(32)]
        public string BuyerSysId { get; set; } = string.Empty;

        [StringLength(32)]
        public string BuyerSysDesc { get; set; } = string.Empty;

        public byte[] BuyerSysIdAsBytes { get; set; } = new byte[0];
    }
}
