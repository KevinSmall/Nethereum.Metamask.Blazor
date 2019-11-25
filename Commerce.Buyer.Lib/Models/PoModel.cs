using System.ComponentModel.DataAnnotations;

namespace Commerce.Buyer.Lib.Models
{
    public class PoModel
    {
        [Required]
        public ulong EthPurchaseOrderNumber { get; set; }

        [Required]
        [StringLength(32)]
        public string BuyerSysId { get; set; }

        [Required]
        [StringLength(32)]
        public string BuyerPurchaseOrderNumber { get; set; }

        [Required]
        [StringLength(32)]
        public string SellerSysId { get; set; }

        [StringLength(32)]
        public string SellerSalesOrderNumber { get; set; }

        [StringLength(32)]
        public string SellerProductId { get; set; }

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

        public uint OpenInvoiceQuantity { get; set; }

        public uint OpenInvoiceValue { get; set; }

        public byte PoStatus { get; set; }

        public string PoStatusDesc { get; set; }

        public byte WiProcessStatus { get; set; }
    }
}
