using Dapr.Workflow;

namespace Api;

[ExtendObjectType(Name = "Mutation")]
public class NewSickReportMutation
{
    private readonly WorkflowEngineClient _workflowEngineClient;
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
        /*var workflowReference = await _workflowEngineClient
            .ScheduleNewWorkflowAsync("SickenessReporting", referenceId, sickReport);*/
        
        await _workflowEngineClient.ScheduleNewWorkflowAsync(
            name: "SicknessReporting",
            instanceId: referenceId,
            input: sickReport);
        
        WorkflowState state = await _workflowEngineClient.GetWorkflowStateAsync(
            instanceId: referenceId,
            getInputsAndOutputs: true);
        while (!state.IsWorkflowCompleted)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            state = await _workflowEngineClient.GetWorkflowStateAsync(
                instanceId: referenceId,
                getInputsAndOutputs: true);
        }
        
        return new NewSickReportPayload(referenceId);
    }
}