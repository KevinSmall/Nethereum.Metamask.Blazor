using Commerce.Buyer.Lib.Contracts.PoMain.ContractDefinition;
using Commerce.Buyer.Lib.Contracts.WalletBuyer.ContractDefinition;
using Commerce.Buyer.Lib.Models;

namespace Commerce.Buyer.Lib.Services
{
    public interface IFieldMapper
    {
        Contracts.WalletBuyer.ContractDefinition.Po MapFieldsPoCreateModelToPo(string buyerSysId, PoCreateModel poModel);
        PoModel MapFieldsPoToPoModel(Contracts.PoMain.ContractDefinition.Po po);
        PoModel MapFieldsPoToPoModel(Contracts.WalletBuyer.ContractDefinition.Po po);
    }
}