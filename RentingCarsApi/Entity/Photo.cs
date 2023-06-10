namespace RentingCarsApi.Entity
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public string CarsVin { get; set; }
        public Cars Cars { get; set; }
    }
}
