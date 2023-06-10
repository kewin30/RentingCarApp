namespace RentingCarsApi.DTO.PostPut_Dtos
{
    public class RentTheCarDto
    {
        public string Vin { get; set; }
        public DateOnly RentedFrom { get; set; }
        public DateOnly RentedTo { get; set; }
    }
}
