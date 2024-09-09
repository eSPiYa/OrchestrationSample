using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Orchestrator.WorkFlows.FileGen.Steps
{
    public class GenerateFileAsync : StepBodyAsync
    {
        public object? Payload { get; set; } = null!;

        public object? RequestResult { get; set; }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
