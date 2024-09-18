
public static class VoterRouteMapper
{
    public static void Map(WebApplication app)
    {
        RouteGroupBuilder voterApi = app.MapGroup("/api/voter");

        voterApi.MapGet("/", VoterApi.GetAllVoters);
        voterApi.MapGet("/voted", VoterApi.GetVotedVoters);
        voterApi.MapGet("/{id}", VoterApi.GetVoter);
        voterApi.MapPost("/", VoterApi.CreateVoter);
        voterApi.MapPut("/{id}", VoterApi.UpdateVoter);
        voterApi.MapDelete("/{id}", VoterApi.DeleteVoter);
    }
}

