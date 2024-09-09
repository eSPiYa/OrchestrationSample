using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Orchestrator.WorkFlows.Rater.Steps
{
    public class SaveCompRaterDataAsync : StepBodyAsync
    {
        public object Data { get; set; } = null!;
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
