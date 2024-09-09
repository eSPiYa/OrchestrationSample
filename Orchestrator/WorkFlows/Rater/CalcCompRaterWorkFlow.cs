using Orchestrator.Common.WorkFlows;
using Orchestrator.WorkFlows.DocGen.Steps;
using Orchestrator.WorkFlows.FileGen.Steps;
using Orchestrator.WorkFlows.Rater.Sagas;
using Orchestrator.WorkFlows.Rater.Steps;
using WorkflowCore.Interface;

namespace Orchestrator.WorkFlows.Rater
{
    public class CalcCompRaterWorkFlow : IWorkflow<CalcCompRaterSaga>
    {
        public string Id => nameof(RaterWorkFlowsEnum.CalcCompRaterWorkFlow);

        public int Version => 1;

        #region IWorkflow
        public void Build(IWorkflowBuilder<CalcCompRaterSaga> builder)
        {
            builder
                .StartWith(context =>
                {
                    // initialize workflow by fetching required data here
                })
                .Saga(saga => 
                    saga
                        .StartWith<CallCalcCompRaterAsync>()
                            .Input(step => step.Payload, data => data.PayLoad)
                            .Output(data => data.RaterResult, step => step.RequestResult)
                            .OnError(WorkflowCore.Models.WorkflowErrorHandling.Terminate)
                        .Then<SaveCompRaterDataAsync>()
                            .Input(step => step.Data, data => data.RaterResult)
                            .OnError(WorkflowCore.Models.WorkflowErrorHandling.Terminate)
                        .Then(context =>
                        {
                            // transform RaterResult into format that is compatible to GenerateDocumentSaga.Payload
                        })
                        .Then<GenerateDocumentAsync>()
                            .Input(step => step.Payload, data => data.GenerateDocumentSaga.Payload)
                            .Output(data => data.GenerateDocumentSaga.RequestResult, step => step.RequestResult)
                            .OnError(WorkflowCore.Models.WorkflowErrorHandling.Retry, TimeSpan.FromSeconds(5))
                        .Then(context =>
                        {
                            // transform GenerateDocumentSaga.RequestResult into format that is compatible to GenerateFileSaga.Payload
                        })
                        .Then<GenerateFileAsync>()
                            .Input(step => step.Payload, data => data.GenerateFileSaga.Payload)
                            .Output(data => data.GenerateFileSaga.RequestResult, step =>step.RequestResult)
                            .OnError(WorkflowCore.Models.WorkflowErrorHandling.Retry, TimeSpan.FromSeconds(5))
                        .Then(context =>
                        {
                            // transform GenerateFileSaga.RequestResult to be sent back to the requester
                        })
                        .Then(context =>
                        {
                            // send back the transformed data to the requester
                        })
                            .OnError(WorkflowCore.Models.WorkflowErrorHandling.Retry, TimeSpan.FromSeconds(5))
                )
                .EndWorkflow();
        }
        #endregion
    }
}
