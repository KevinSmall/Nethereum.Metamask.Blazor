using Commerce.Buyer.Lib.Models;
using PoBuyer = Commerce.Buyer.Lib.Contracts.WalletBuyer.ContractDefinition;
using PoMain = Commerce.Buyer.Lib.Contracts.PoMain.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib.Services
{
    public class FieldMapper : IFieldMapper
    {
        public PoModel MapFieldsPoToPoModel(PoMain.Po po)
        {
            return new PoModel
            {
                EthPurchaseOrderNumber = po.EthPurchaseOrderNumber,
                BuyerSysId = po.BuyerSysId,
                BuyerPurchaseOrderNumber = po.BuyerPurchaseOrderNumber,
                SellerSysId = po.SellerSysId,
                SellerSalesOrderNumber = po.SellerSalesOrderNumber,
                SellerProductId = po.SellerProductId,
                BuyerProductId = po.BuyerProductId,
                Currency = po.Currency,
                CurrencyAddress = po.CurrencyAddress,
                TotalQuantity = po.TotalQuantity,
                TotalValue = po.TotalValue,
                OpenInvoiceQuantity = po.OpenInvoiceQuantity,
                OpenInvoiceValue = po.OpenInvoiceValue,
                PoStatus = po.PoStatus,
                PoStatusDesc = GetStatusDescription(po.PoStatus),
                WiProcessStatus = po.WiProcessStatus
            };
        }

        public PoModel MapFieldsPoToPoModel(PoBuyer.Po po)
        {
            return new PoModel
            {
                EthPurchaseOrderNumber = po.EthPurchaseOrderNumber,
                BuyerSysId = po.BuyerSysId,
                BuyerPurchaseOrderNumber = po.BuyerPurchaseOrderNumber,
                SellerSysId = po.SellerSysId,
                SellerSalesOrderNumber = po.SellerSalesOrderNumber,
                SellerProductId = po.SellerProductId,
                BuyerProductId = po.BuyerProductId,
                Currency = po.Currency,
                CurrencyAddress = po.CurrencyAddress,
                TotalQuantity = po.TotalQuantity,
                TotalValue = po.TotalValue,
                OpenInvoiceQuantity = po.OpenInvoiceQuantity,
                OpenInvoiceValue = po.OpenInvoiceValue,
                PoStatus = po.PoStatus,
                PoStatusDesc = GetStatusDescription(po.PoStatus),
                WiProcessStatus = po.WiProcessStatus
            };
        }

        public PoBuyer.Po MapFieldsPoCreateModelToPo(string buyerSysId, PoCreateModel poModel)
        {
            return new PoBuyer.Po
            {
                //EthPurchaseOrderNumber;                               // leave initial, filled by PoMain
                BuyerSysId = buyerSysId,
                BuyerPurchaseOrderNumber = poModel.BuyerPurchaseOrderNumber,
                BuyerViewVendorId = string.Empty,                       // leave initial, filled by PoMain
                SellerSysId = poModel.SellerSysId,
                SellerSalesOrderNumber = string.Empty,                  // leave initial, filled by PoMain
                SellerViewCustomerId = string.Empty,                    // leave initial, filled by PoMain
                BuyerProductId = poModel.BuyerProductId,
                SellerProductId = string.Empty,                         // leave initial, filled by PoMain
                Currency = poModel.Currency,
                CurrencyAddress = poModel.CurrencyAddress,
                TotalQuantity = poModel.TotalQuantity,
                TotalValue = poModel.TotalValue,
                //OpenInvoiceQuantity; leave initial, filled by PoMain
                //OpenInvoiceValue; leave initial, filled by PoMain
                //PoStatus; leave initial, filled by PoMain
                //WiProcessStatus; leave initial, filled by PoMain
            };
        }

        private string GetStatusDescription(byte poStatus)
        {
            string description = "Initial";
            if (poStatus == 1) description = "Purchase Order Created";
            else if (poStatus == 2) description = "Sales Order Received";
            else if (poStatus == 3) description = "Completed";
            else if (poStatus == 4) description = "Cancelled";
            return description;
        }
    }
}
