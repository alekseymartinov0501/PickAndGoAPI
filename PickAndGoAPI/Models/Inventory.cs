using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Models
{
    public class Inventory
    {
        [Key]
        public int id { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public double CurrentPrice { get; set; }
        public double CurrentCost { get; set; } // Current average purchase price.
        public int ProfitPercentage { get; set; }
    }
}
