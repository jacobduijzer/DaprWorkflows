using Dapr.Workflow;

namespace SickReportingWorkflow.Workflows;

public class SicknessReporting : Workflow<SickReport, bool>
{
    public override async Task<bool> RunAsync(WorkflowContext context, SickReport input)
    {
        var result = await context.CallActivityAsync<bool>(
            nameof(SicknessReporting),
            input);
        
        return true;
    }
}