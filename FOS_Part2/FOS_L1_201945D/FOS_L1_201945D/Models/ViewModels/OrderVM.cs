using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Models.ViewModels
{
    public class OrderVM
    {
        public List<Fruit> Fruits { get; set; }
        
        public List<int> Quantity { get; set; }
    }
}
