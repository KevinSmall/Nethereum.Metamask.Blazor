using Commerce.Buyer.Lib.Services;
using Common.Logging;
using Nethereum.Web3;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib
{
    public class BuyerUILib : IBuyerUILib
    {
        public IWallet Wallet { get; private set; }
        public IPurchaseOrder PurchaseOrder { get; private set; }
        public IEventLogs EventLogs { get; private set; }

        private bool _hasBeenInitialized;

        public BuyerUILib(Web3 web3, string walletBuyerAddress, ILog log = null)
        {
            Wallet = new Wallet(web3, walletBuyerAddress, log);
            IFieldMapper mapper = new FieldMapper();
            PurchaseOrder = new PurchaseOrder(Wallet, mapper, log);
            EventLogs = new EventLogs(Wallet, mapper, log);
            _hasBeenInitialized = false;
        }

        public async Task InitializeAsync()
        {
            if (!_hasBeenInitialized)
            {
                await Wallet.InitializeAsync();
                _hasBeenInitialized = true;
            }
        }
    }
}
