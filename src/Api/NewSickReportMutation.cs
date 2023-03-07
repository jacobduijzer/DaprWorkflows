using Dapr.Client;
using Dapr.Workflow;

namespace Api;

[ExtendObjectType(Name = "Mutation")]
public class NewSickReportMutation
{
    private readonly WorkflowEngineClient _workflowEngineClient;
    private readonly DaprClient _daprClient;
    private readonly ILogger<NewSickReportMutation> _logger;

    public NewSickReportMutation(
        WorkflowEngineClient workflowEngineClient,
        ILogger<NewSickReportMutation> logger)
    {
        _workflowEngineClient = workflowEngineClient;
        _logger = logger;
    }

    public async Task<NewSickReportPayload> AddNewSickReport(SickReport sickReport)
    {
        var referenceId = Guid.NewGuid().ToString();
        var workflowReference = await _workflowEngineClient
            .ScheduleNewWorkflowAsync("SickenessReporting", referenceId, sickReport);
        
        return new NewSickReportPayload(workflowReference);
    }
}