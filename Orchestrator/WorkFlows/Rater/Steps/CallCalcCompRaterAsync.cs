using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Orchestrator.WorkFlows.Rater.Steps
{
    public class CallCalcCompRaterAsync: StepBodyAsync
    {
        public object Payload { get; set; } = null!;

        public object RequestResult { get; set; } = null!;

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
