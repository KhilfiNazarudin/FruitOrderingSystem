using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FOS_L1_201945D.Models
{
    public partial class FruitCategory
    {
        public FruitCategory()
        {
            Fruit = new HashSet<Fruit>();
        }

        public FruitCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public FruitCategory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Fruit> Fruit { get; set; }
    }
}
