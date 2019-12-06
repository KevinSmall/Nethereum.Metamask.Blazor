using Microsoft.AspNetCore.Components;
using Commerce.Buyer.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Buyer.PoBlazorComponents 
{
    public class MyComponent1Base : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public IBuyerUILib BuyerUILib { get; set; }
    }
}
