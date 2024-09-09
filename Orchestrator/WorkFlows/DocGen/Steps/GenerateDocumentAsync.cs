using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Orchestrator.WorkFlows.DocGen.Steps
{
    public class GenerateDocumentAsync : StepBodyAsync
    {
        public object? Payload { get; set; } = null!;

        public object? RequestResult { get; set; }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
