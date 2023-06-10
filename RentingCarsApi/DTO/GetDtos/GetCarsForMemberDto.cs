namespace RentingCarsApi.DTO.GetDtos
{
    public class GetCarsForMemberDto
    {
        public string Vin { get; set; }
        public string Model { get; set; }
        public int CarYear { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public int PrizeForDay { get; set; }
        public int PrizeForWeek { get; set; }
        public string Place { get; set; }
        public string Url { get; set; }
    }
}
