//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace resturant_pro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int orderId { get; set; }
        public Nullable<int> MealId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Meal Meal { get; set; }
        public virtual User User { get; set; }
    }
}
