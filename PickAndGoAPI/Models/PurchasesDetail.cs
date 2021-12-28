using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Models
{
    public class PurchasesDetail
    {
        [Key]
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int ProfitPercentage { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public PurchasesOrder Order { get; set; }
        public double Total { get; set; }
    }
}
