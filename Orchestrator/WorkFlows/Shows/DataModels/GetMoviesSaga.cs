using Orchestrator.Common.Models;

namespace Orchestrator.WorkFlows.Shows.DataModels
{
    public class GetMoviesSaga : GetMoviesModel
    {
        public string? ConnectionId { get; set; }
        public string? GetMoviesHttpResponse { get; set; }
    }
}
