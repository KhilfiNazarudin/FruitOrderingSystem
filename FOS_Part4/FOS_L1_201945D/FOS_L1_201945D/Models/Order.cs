using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FOS_L1_201945D.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
