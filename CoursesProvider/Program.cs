using Courses.Infrastructure.Data.Contexts;
using Courses.Infrastructure.GraphQL.Mutations;
using Courses.Infrastructure.GraphQL.ObjectTypes;
using Courses.Infrastructure.GraphQL.Queries;
using Courses.Infrastructure.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        
        //Scopes
        services.AddScoped<ICourseService, CourseService>();



        //Database options (Azure Cosmos)
        services.AddPooledDbContextFactory<DataContext>(options =>
        {
            options.UseCosmos(
                Environment.GetEnvironmentVariable("CosmosDbConnectionString")!,
                Environment.GetEnvironmentVariable("CosmosDbDatabaseName")!)
            .UseLazyLoadingProxies();
        });

        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        using var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Database.EnsureCreated();


        //GraphQL options
        services.AddGraphQLFunction()
                .AddQueryType<Query>()
                .AddMutationType<CourseMutation>()
                .AddType<CourseType>();
    })
    .Build();

host.Run();
