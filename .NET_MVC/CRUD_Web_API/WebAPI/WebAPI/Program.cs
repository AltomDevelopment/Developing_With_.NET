using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MVCforAPIExample.Options;
using WebAPI.Models;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureOptions<DatabaseOptionsSetup>();
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IDCandidateRepository, DCandidateRepository>();
        builder.Services.AddCors();

        //builder.Services.AddDbContext<DonationDBContext> 
        builder.Services.AddDbContextFactory<DonationDBContext>(
            (serviceProvider, dbContextOptionsBuilder) =>
            {
                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
                {
                    sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                    sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);

                }); //Adding the services or options to the WebApplication builder

                dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);

                dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            });

        var app = builder.Build();

        app.UseCors(options =>
        options.WithOrigins("http://localhost:3000/")
        .AllowAnyHeader()
        .AllowAnyMethod());

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.MapRazorPages();

        app.Run();
    } 
}




