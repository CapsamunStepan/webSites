using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ItemsAndPersonalDataModel
    {
        public CartItemsModel Model { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street_name { get; set; }
        public string Payment { get; set; }
    }
}
