using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FOS_L1_201945D.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FruitId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Fruit Fruit { get; set; }
        public virtual Order Order { get; set; }
    }
}
