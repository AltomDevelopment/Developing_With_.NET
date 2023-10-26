using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using WebAPI.Models;

namespace MVCforAPIExample.Options
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

            _configuration.GetSection(ConfigureSectionName).Bind(options);

             //Add command timeout for your code to run 
        }
    }
}