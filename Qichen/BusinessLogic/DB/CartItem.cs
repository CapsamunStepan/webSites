//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLogic.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartItem
    {
        public int CartItem_ID { get; set; }
        public int Cart_ID { get; set; }
        public int Item_ID { get; set; }
        public int Item_Amount { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Item Item { get; set; }
    }
}
