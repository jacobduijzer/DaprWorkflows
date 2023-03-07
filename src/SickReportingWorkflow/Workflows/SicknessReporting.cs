using Dapr.Workflow;
using SickReportingWorkflow.Activities;

namespace SickReportingWorkflow.Workflows;

public class SicknessReporting : Workflow<SickReport, bool>
{
    public override async Task<bool> RunAsync(WorkflowContext context, SickReport input)
    {
        var result = await context.CallActivityAsync<bool>(
            nameof(PredictActivity),
            input);
        
        return true;
    }
}