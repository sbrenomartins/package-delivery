namespace MinimalApi.Delivery.DTOs
{
    public class PackageLocation
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
    }
}
