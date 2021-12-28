using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.InventoryControl.Request
{
    public class InventoryRequest
    {
        public PurchasesDetail PurchaseDetail { get; set; }
        public int ProfitPercentage { get; set; }
    }
}
