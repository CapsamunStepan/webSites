using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CartItemsModel
    {
        public int Cart_ID { get; set; }
        public List<AdditionalItem> cartItems { get; set; }
        public double TotalPrice { get; set; }
    }
    public class AdditionalItem
    {
        public Item item { get; set; }
        public int itemAmount { get; set; }

    }
}
