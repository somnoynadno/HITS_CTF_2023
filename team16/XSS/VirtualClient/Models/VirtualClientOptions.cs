namespace PlaywrightClient.Models
{
    public class VirtualClientOptions
    {
        public int VisitFrequency { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnectionString { get; set; }
        public string TargetBoardId { get; set; }
    }
}
