using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;
using Commerce.Metamask.Blazor.Server.Services;

namespace Commerce.Metamask.Blazor.Server.Components
{
    public class TxReceiptBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public TransactionReceipt Receipt { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string BlockchainUrl { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string AdditionalMessage { get; set; }

        public string TransactionReceiptHash { get; private set; }
        public string TransactionReceiptLink { get; private set; }
        public ulong TransactionBlockNumber { get; private set; }
        public bool IsTransactionError { get; private set; }

        [Inject]
        public IWalletBuyer WalletBuyer { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            string blockchainName = this.WalletBuyer.Lib.Wallet.Info.BlockchainName;
            TransactionReceiptHash = Receipt?.TransactionHash;
            TransactionReceiptLink = DeriveBaseUrl(blockchainName) + TransactionReceiptHash;

            if (Receipt != null && Receipt.BlockNumber != null)
            {
                TransactionBlockNumber = (ulong)Receipt.BlockNumber.Value;
            }
            
            IsTransactionError = false;
            if (Receipt != null && Receipt.Status.Value == 0)
                IsTransactionError = true;

            base.OnParametersSet();
        }

        private string DeriveBaseUrl(string blockchainName)
        {
            blockchainName = blockchainName.ToLower();
            if (blockchainName.Contains("rinkeby"))
            {
                return "https://rinkeby.etherscan.io/tx/";
            }
            else if (blockchainName.Contains("ropsten"))
            {
                return "https://ropsten.etherscan.io/tx/";
            }
            else
            {
                return "https://etherscan.io/tx/";
            }
        }
    }
}
