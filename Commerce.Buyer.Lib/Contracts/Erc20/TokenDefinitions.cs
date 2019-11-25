using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib.Contracts.Erc20
{
        [Function("name", "string")]
        public class NameFunction : FunctionMessage { }

        [Function("symbol", "string")]
        public class SymbolFunction : FunctionMessage { }

        [Function("decimals", "uint8")]
        public class DecimalsFunction : FunctionMessage { }

        [Function("balanceOf", "uint256")]
        public class BalanceOfFunction : FunctionMessage
        {
            [Parameter("address", "_owner", 1)] public string Owner { get; set; }
        } 
}
