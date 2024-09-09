using Orchestrator.Common.Models.DocGen;

namespace Orchestrator.WorkFlows.DocGen.Sagas
{
    public class GenerateDocumentSaga: GenerateDocumentModel
    {
        public object? RequestResult { get;set; }
    }
}
