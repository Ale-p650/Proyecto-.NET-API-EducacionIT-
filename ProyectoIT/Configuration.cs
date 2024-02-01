namespace ProyectoIT
{
    public static class Configuration
    {
        public static string Config()
        {
            var config = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var x = config.Build();
            return x.GetConnectionString("Conn");
        }
    }
}
