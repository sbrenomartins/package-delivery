namespace MinimalApi.Package.DTOs
{
    public class RegisterPackageDto
    {
        public int PackageId { get; set; }
        public string Code { get; set; } = string.Empty; 
        public string Country { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
