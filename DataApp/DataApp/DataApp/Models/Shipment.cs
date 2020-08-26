using System.Collections;
using System.Collections.Generic;

namespace DataApp.Models
{
    public class Shipment
    {
        public long Id { get; set; }

        public string ShipperName { get; set; }

        public string StartCity { get; set; }

        public string EndCity { get; set; }

        public IEnumerable<ProductShipmentJunction> ProductShipments { get; set; }
    }

    public class ProductShipmentJunction
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long ShipmentId { get; set; }

        public Shipment Shipment { get; set; }
    }
}
