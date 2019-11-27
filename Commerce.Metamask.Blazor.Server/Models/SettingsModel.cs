using System.ComponentModel.DataAnnotations;

namespace Commerce.Metamask.Blazor.Server.Models
{
    public class SettingsModel
    {
        public string BlockchainUrl { get; set; }
        public string WalletBuyerAddress { get; set; }
        public string BusinessPartnersContractAddress { get; set; }        
    }
}
