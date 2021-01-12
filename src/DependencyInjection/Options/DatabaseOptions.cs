namespace DependencyInjection.Options
{
    public class DatabaseOptions
    {
        public const string Position = "Database";

        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }
    }
}
