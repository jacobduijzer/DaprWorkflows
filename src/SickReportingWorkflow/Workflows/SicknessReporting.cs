using Api;
using Dapr.Workflow;
using SickReportingWorkflow.Activities;

namespace SickReportingWorkflow.Workflows;

public class SicknessReporting : Workflow<SickReport, bool>
{
    public override async Task<bool> RunAsync(WorkflowContext context, SickReport input)
    {
        Console.WriteLine("Line 1");
        try
        {
            await context.CallActivityAsync(
                nameof(NotifyActivity),
                new Notification($"Received sickReport for {input.FirstName} {input.LastName}"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
             throw;
        }
        
        // var result = await context.CallActivityAsync<bool>(
        //     nameof(PredictActivity),
        //     input);
        
        Console.WriteLine("Line 2");
        
        return true;
    }
}