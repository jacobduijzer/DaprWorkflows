using Api;
using Dapr.Client;
using Dapr.Workflow;

namespace SickReportingWorkflow.Activities;

public class PredictActivity : WorkflowActivity<SickReport, bool>
{
    private readonly ILogger<PredictActivity> _logger;
    private readonly DaprClient _client;

    public PredictActivity(ILogger<PredictActivity> logger, DaprClient client)
    {
        _logger = logger;
        _client = client;
    }
    
    public override async Task<bool> RunAsync(WorkflowActivityContext context, SickReport input)
    {
       _logger.LogInformation("Processing Prediction Request");
       return await Task.FromResult(true);
    }
}