namespace DependencyInjection.Options
{
    public class SecretOptions
    {
        public const string Position = "Secret";

        public string Hostname { get; set; }
        public string Token { get; set; }
    }
}
