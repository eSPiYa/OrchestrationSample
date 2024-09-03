using Orchestrator.WorkFlows.Shows.DataModels;
using Orchestrator.WorkFlows.Shows;
using WorkflowCore.Interface;

namespace Orchestrator.Extensions
{
    public static class WorkFlowExtensions
    {
        public static void RegisterWorkFlows(this IServiceProvider serviceProvider)
        {
            var host = serviceProvider.GetService<IWorkflowHost>();
            host!.RegisterWorkflow<GetMoviesWorkFlow, GetMoviesSaga>();
            host!.RegisterWorkflow<GetShowsListsWorkFlow, GetShowsListsSaga>();
            host.Start();
        }
    }
}
