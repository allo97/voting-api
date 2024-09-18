
public static class CandidateRouteMapper
{
    public static void Map(WebApplication app)
    {
        RouteGroupBuilder candidateApi = app.MapGroup("/api/candidate");

        candidateApi.MapGet("/", CandidateApi.GetAllCandidates);
        candidateApi.MapGet("/{id}", CandidateApi.GetCandidate);
        candidateApi.MapPost("/", CandidateApi.CreateCandidate);
        candidateApi.MapPut("/{id}", CandidateApi.UpdateCandidate);
        candidateApi.MapDelete("/{id}", CandidateApi.DeleteCandidate);
    }
}

