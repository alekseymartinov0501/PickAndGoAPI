using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public int BarCode { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public DateTime ElaborationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Weight { get; set; }
        public int Volumen { get; set; }
        public int QualityRegistryId { get; set; }
        [ForeignKey("QualityRegistryId")]
        public QualityRegistry QualityRegistry { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int DistributionId { get; set; }
        [ForeignKey("DistributionId")]
        public Distribution Distribution { get; set; }
        public string ImageUrl { get; set;}
        public bool Available { get; set; }
        public bool Active { get; set; }

    }
}
