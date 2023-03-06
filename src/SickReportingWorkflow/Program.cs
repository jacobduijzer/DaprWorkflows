using Dapr.Workflow;
using SickReportingWorkflow;
using SickReportingWorkflow.Activities;
using SickReportingWorkflow.Workflows;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(async services =>
    {
        // while (true)
        // {
        //     await Task.Delay(500);
        //     Console.WriteLine("Tick");
        // }
        services.AddDaprClient();
        services.AddDaprWorkflow(options =>
        {
            //     options.RegisterWorkflow<SicknessReporting>();
            //     options.RegisterActivity<PredictActivity>();
            //     
            //     
        });
        // services.AddHostedService<Worker>();
    });

using var host = builder.Build();
host.Run();


//
// var builder = WebApplication.CreateBuilder(args);
// {
//     builder.Services.AddDaprWorkflow(options =>
//     {
//         options.RegisterWorkflow<SicknessReporting>();
//         options.RegisterActivity<PredictActivity>();
//     });
// }
// var app = builder.Build();
// app.UseCloudEvents();
// app.MapSubscribeHandler();
// app.Run();
