using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModel
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> CartItemList { get; set; } // print cartitem List of a user
        public OrderHeader OrderHeader { get; set; } // acts as vm
        public double OrderTotal { get; set; }
       
    }
}
