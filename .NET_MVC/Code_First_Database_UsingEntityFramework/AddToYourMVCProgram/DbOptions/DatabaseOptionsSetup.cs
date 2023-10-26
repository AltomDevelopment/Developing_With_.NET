namespace Code_First_Database_UsingEntityFramework.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private const string ConfigureSectionName = "DatabaseOptions";

        private readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            var connectionString = _configuration.GetConnectionString("DevConnection");

            options.ConnectionString = connectionString;

            options.CommandTimeout = 30;

            //Binding the Section so we can configure in the Program Class
            _configuration.GetSection(ConfigureSectionName).Bind(options);
        }
    }
}