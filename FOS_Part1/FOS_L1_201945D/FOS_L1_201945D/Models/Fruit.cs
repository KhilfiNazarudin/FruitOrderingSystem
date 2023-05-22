using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FOS_L1_201945D.Models
{
    public partial class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int FruitCategoryId { get; set; }

        public virtual FruitCategory FruitCategory { get; set; }
    }
}
