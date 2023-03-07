using Api;
using Dapr.Workflow;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDaprClient();
    builder.Services
        .AddGraphQLServer()
        .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
        .AddQueryType(with => with.Name("Query"))
        .AddTypeExtension<TestQueries>()
        .AddMutationType(with => with.Name("Mutation"))
        .AddTypeExtension<NewSickReportMutation>()
        .AddInMemorySubscriptions();
    builder.Services.AddDaprWorkflow(options =>
    {
    });
}

var app = builder.Build();
{
    app.UseCloudEvents();
    app.MapSubscribeHandler();
    app.MapGraphQL();
    app.UseWebSockets();
    app.UseRouting();
    app.Run();
}