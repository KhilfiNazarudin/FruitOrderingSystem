using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Models.ViewModels
{
    public class OrderVM
    {
        [Required(ErrorMessage = "Please enter an address")]
        [MaxLength(256)]
        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public DateTime Date { get; set; }

        public List<Fruit> Fruits { get; set; }

        public int SelectedFruitId { get; set; }

        public int quantity { get; set; }
        
        public List<Items> itemList { get; set; }


    }
}
