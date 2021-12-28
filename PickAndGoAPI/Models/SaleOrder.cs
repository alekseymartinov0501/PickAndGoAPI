using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Models
{
    public class SaleOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double GrandTotal { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Product { get; set; }
        public string Status { get; set; }

    }
}
