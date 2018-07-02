using System;
namespace Jenseits.Models
{
    public class Shipment
    {
        public string UserId { get; set; }

        public string ShipFromAirport { get; set; }

        public DateTime ShippingDate { get; set; }

        public string ShiptoAirport { get; set; }

        public int PackageWeight { get; set; }

        public string PackageDimensions { get; set; }

        public string PackageCategory { get; set; }

    }
}
