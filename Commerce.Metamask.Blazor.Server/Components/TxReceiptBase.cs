using Microsoft.AspNetCore.Components;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Commerce.Metamask.Blazor.Server.Models;

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

        //[Inject]
        //public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            TransactionReceiptHash = Receipt?.TransactionHash;
            TransactionReceiptLink = DeriveBaseUrl(BlockchainUrl) + TransactionReceiptHash;

            if (Receipt != null && Receipt.BlockNumber != null)
            {
                TransactionBlockNumber = (ulong)Receipt.BlockNumber.Value;
            }
            
            IsTransactionError = false;
            if (Receipt != null && Receipt.Status.Value == 0)
                IsTransactionError = true;

            base.OnParametersSet();
        }

        private string DeriveBaseUrl(string blockchainUrl)
        {
            if (blockchainUrl.Contains("rinkeby"))
            {
                return "https://rinkeby.etherscan.io/tx/";
            }
            else if (blockchainUrl.Contains("ropsten"))
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
