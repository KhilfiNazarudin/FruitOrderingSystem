using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Models.ViewModels
{
    public class searchFruitsByCat
    {
        public List<Fruit> FruitList { get; set; }
        public List<FruitCategory> CategoryList { get; set; }

        public string searchedTerm { get; set; }
        
    }
}
