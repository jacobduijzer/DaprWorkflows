using Dapr.Client;

namespace Api;

[ExtendObjectType(Name = "Mutation")]
public class NewSickReportMutation
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<NewSickReportMutation> _logger;

    public NewSickReportMutation(DaprClient daprClient, ILogger<NewSickReportMutation> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    public async Task<NewSickReportPayload> AddNewSickReport(SickReport sickReport)
    {
        var workflowReference =
            await _daprClient.StartWorkflowAsync(
                "workflow", 
                "SickReportingWorkflow", 
                "SicknessReporting", sickReport);
        // return new NewSickReportPayload(workflowReference.InstanceId);
        return new NewSickReportPayload("test");
    }
}