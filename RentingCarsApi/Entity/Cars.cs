using System.ComponentModel.DataAnnotations;

namespace RentingCarsApi.Entity
{
    public class Cars
    {
        [Key]
        public string Vin { get; set; }
        public bool GpsEnabled { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public int CarYear { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public int PrizeForDay { get; set; }
        public int PrizeForWeek { get; set; }
        public bool Availability { get; set; }
        public string Place { get; set; }
        public int? UserReservationId { get; set; }
        public AppUser UserReservation { get; set; }
        public bool IsReserved { get; set; }
        public int? UserId { get; set; }
        public AppUser User { get; set; }
        public int UserBeforeId { get; set; }
        public DateOnly RentedFrom { get; set; }
        public DateOnly RentedTo { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public bool HasBeenPaid { get; set; } = false;
    }
}
