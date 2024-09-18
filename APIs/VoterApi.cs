
using Microsoft.EntityFrameworkCore;

public static class VoterApi 
{
    public static async Task<IResult> GetAllVoters(VoterContext context)
    {
        return TypedResults.Ok(await context.Voters.ToArrayAsync());
    }

    public static async Task<IResult> GetVotedVoters(VoterContext context) {
        return TypedResults.Ok(await context.Voters.Where(t => t.Voted).ToListAsync());
    }

    public static async Task<IResult> GetVoter(int id, VoterContext context)
    {
        return await context.Voters.FindAsync(id)
            is Voter voter
                ? TypedResults.Ok(voter)
                : TypedResults.NotFound();
    }

    public static async Task<IResult> CreateVoter(Voter voter, VoterContext context)
    {
        context.Voters.Add(voter);
        await context.SaveChangesAsync();

        return TypedResults.Created($"/api/voter/{voter.Id}", voter);
    }

    public static async Task<IResult> UpdateVoter(int id, Voter inputVoter, VoterContext context)
    {
        var voter = await context.Voters.FindAsync(id);

        if (voter is null) return TypedResults.NotFound();

        voter.Name = inputVoter.Name;
        voter.Voted = inputVoter.Voted;

        await context.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteVoter(int id, VoterContext context)
    {
        if (await context.Voters.FindAsync(id) is Voter voter)
        {
            context.Voters.Remove(voter);
            await context.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }
}

