using Dapr.Workflow;
using SickReportingWorkflow.Activities;
using SickReportingWorkflow.Workflows;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDaprWorkflow(options =>
    {
        options.RegisterWorkflow<SicknessReporting>();
        options.RegisterActivity<PredictActivity>();
    });
}
var app = builder.Build();
app.Run();
