using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Models
{
    public class Distribution
    {
        [Key]
        public int id { get; set; }
        public int AisleId { get; set; }
        [ForeignKey("AisleId")]
        public Aisle Aisle { get; set; }
        public int AisleSequenceId { get; set; }
        [ForeignKey("AisleSequenceId")]
        public SequenceAisle SequenceAisle { get; set; }
    }
}
