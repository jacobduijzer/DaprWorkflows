using Dapr.Workflow;
using SickReportingWorkflow;
using SickReportingWorkflow.Activities;
using SickReportingWorkflow.Workflows;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(async services =>
    {
        services.AddDaprClient();
        services.AddDaprWorkflow(options =>
        {
            options.RegisterWorkflow<SicknessReporting>();
            options.RegisterActivity<PredictActivity>();

            //     
        });
        // services.AddHostedService<Worker>();
    }).Build();

await host.RunAsync();