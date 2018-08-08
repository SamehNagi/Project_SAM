using System;
namespace Jenseits.Models
{
    public enum PackageSize
    {
        Small,
        Medium,
        Big
    }
    
    public class Trip
    {
        public string UserId { get; set; }

        public string FromAirport { get; set; }

        public DateTime DepartureDate { get; set; }

        public string ToAirport { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string FlightNumber { get; set; }

        public string TicketNumber { get; set; }

        public string TicketPhotoCopy { get; set; }

        public string VisaNumber { get; set; }

        public string VisaValidUntil { get; set; }

        public string VisaPhotoCopy { get; set; }

        public int FreeWeight { get; set; }

        public string AllowedPackageDimensions { get; set; }

        public PackageSize PackageSize { get; set; }

        public string PickUpMethod { get; set; }

        public string ItemWeigth { get; set; }

        public string Status { get; set; }

        public bool Verified { get; set; }

        public string VerifiedStatus =>  Verified ? "checkmark.png" : "redAlert.png";
    }
}
