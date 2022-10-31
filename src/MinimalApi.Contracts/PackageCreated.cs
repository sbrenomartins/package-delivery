namespace MinimalApi.Contracts
{
    public class PackageCreated
    {
        public int PackageId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTimeOffset TimeStamp { get; set; }
    }
}