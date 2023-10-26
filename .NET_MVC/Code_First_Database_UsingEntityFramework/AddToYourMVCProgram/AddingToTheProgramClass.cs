

builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

builder.Services.AddDbContext<DomainContext>(
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