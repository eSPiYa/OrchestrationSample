using Orchestrator.WorkFlows.Shows.DataModels;
using Orchestrator.WorkFlows.Shows;
using WorkflowCore.Interface;
using Orchestrator.WorkFlows.Rater;
using Orchestrator.WorkFlows.Steps;
using Orchestrator.WorkFlows.Rater.Steps;
using Orchestrator.WorkFlows.DocGen.Steps;
using Orchestrator.WorkFlows.FileGen.Steps;

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

        public static void InjectWorkFlowsAndSteps(this IServiceCollection services)
        {
            services.InjectWorkFlows();
            services.InjectSteps();
        }
        
        public static void InjectWorkFlows(this IServiceCollection services)
        {
            services.InjectGenericWorkFlows();
            services.InjectFileGenWorkFlows();
            services.InjectDocGenWorkFlows();
            services.InjectRaterWorkFlows();
        }

        public static void InjectSteps(this IServiceCollection services)
        {
            services.InjectGenericSteps();
            services.InjectRaterSteps();
            services.InjectDocGenSteps();
            services.InjectFileGenSteps();
        }

        #region Generic
        public static void InjectGenericWorkFlows(this IServiceCollection services)
        {
            
        }

        public static void InjectGenericSteps(this IServiceCollection services)
        {
            services.AddTransient<GetConnectionId>();
            services.AddTransient<ApiCallAsync>();
        }
        #endregion

        #region Rater
        public static void InjectRaterWorkFlows(this IServiceCollection services)
        {
            services.AddTransient<CalcCompRaterWorkFlow>();
        }

        public static void InjectRaterSteps(this IServiceCollection services)
        {
            services.AddTransient<CallCalcCompRaterAsync>();
            services.AddTransient<SaveCompRaterDataAsync>();
        }
        #endregion

        #region DocGen
        public static void InjectDocGenWorkFlows(this IServiceCollection services)
        {
            
        }

        public static void InjectDocGenSteps(this IServiceCollection services)
        {
            services.AddTransient<GenerateDocumentAsync>();
        }
        #endregion

        #region FileGen
        public static void InjectFileGenWorkFlows(this IServiceCollection services)
        {

        }

        public static void InjectFileGenSteps(this IServiceCollection services)
        {
            services.AddTransient<GenerateFileAsync>();
        }
        #endregion
    }
}
