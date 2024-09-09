using Orchestrator.Common.Models.FileGen;

namespace Orchestrator.WorkFlows.FileGen.Sagas
{
    public class GenerateFileSaga: GenerateFileModel
    {
        public object? RequestResult { get; set; }
    }
}
