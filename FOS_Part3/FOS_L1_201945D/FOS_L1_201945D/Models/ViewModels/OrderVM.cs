using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Models.ViewModels
{
    public class OrderVM
    {
        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public DateTime Date { get; set; }

        public List<Fruit> Fruits { get; set; }

        public int SelectedFruitId { get; set; }

        public int quantity { get; set; }

        public int orderID { get; set; }

        public Order order { get; set; }
    }
}
