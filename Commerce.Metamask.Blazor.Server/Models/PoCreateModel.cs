using System.ComponentModel.DataAnnotations;

namespace Commerce.Metamask.Blazor.Server.Models
{
    public class PoCreateModel
    {
        [Required]
        [StringLength(32)]
        public string BuyerPurchaseOrderNumber { get; set; }

        [Required]
        [StringLength(32)]
        public string SellerSysId { get; set; }

        [Required]
        [StringLength(32)]
        public string BuyerProductId { get; set; }

        [Required]
        [StringLength(32)]
        public string Currency { get; set; }

        [Required]
        [StringLength(42)]
        public string CurrencyAddress { get; set; }

        [Required]
        public uint TotalQuantity { get; set; }

        [Required]
        public uint TotalValue { get; set; }
    }
}
