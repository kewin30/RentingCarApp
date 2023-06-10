namespace RentingCarsApi.DTO.GetDtos
{
    public class GetPaymentFromCar
    {
        public double Prize { get; set; }
        public DateOnly RentedFrom { get; set; }
        public DateOnly RentedTo { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
