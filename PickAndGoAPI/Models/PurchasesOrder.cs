using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Models
{
    public class PurchasesOrder
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public double GrandTotal { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider provider { get; set; }
        public List<PurchasesDetail> PurchasesDetails { get; set; }

    }
}
