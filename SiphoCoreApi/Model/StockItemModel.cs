using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiphoCoreApi.Model
{
    public class StockItemModel
    {
        [Key]
        public Guid id { get; set; }
        public string VehicleRegistration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime ModelYear { get; set; }
        public int KMS { get; set; }
        public string Colour { get; set; }
        public string VIN { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal CostPrice { get; set; }
        public StockAccessoryModel Accessory { get; set; }
        public ImagesModel images { get; set; }
        public DateTime DTCreated { get; set; }
        public DateTime DTUpdated { get; set; }
    }
}
