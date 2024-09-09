using Orchestrator.Common.Models.Rater;
using Orchestrator.WorkFlows.DocGen.Sagas;
using Orchestrator.WorkFlows.FileGen.Sagas;

namespace Orchestrator.WorkFlows.Rater.Sagas
{
    public class CalcCompRaterSaga: CalcCompRaterModel
    {
        public object? RaterResult { get; set; }

        public GenerateDocumentSaga GenerateDocumentSaga { get; set; } = new GenerateDocumentSaga();

        public GenerateFileSaga GenerateFileSaga { get; set; } = new GenerateFileSaga();
    }
}
