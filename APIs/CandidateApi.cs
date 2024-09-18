
using Microsoft.EntityFrameworkCore;

public static class CandidateApi 
{
    public static async Task<IResult> GetAllCandidates(CandidateContext context)
    {
        return TypedResults.Ok(await context.Candidates.ToArrayAsync());
    }

    public static async Task<IResult> GetCandidate(int id, CandidateContext context)
    {
        return await context.Candidates.FindAsync(id)
            is Candidate candidate
                ? TypedResults.Ok(candidate)
                : TypedResults.NotFound();
    }

    public static async Task<IResult> CreateCandidate(Candidate candidate, CandidateContext context)
    {
        context.Candidates.Add(candidate);
        await context.SaveChangesAsync();

        return TypedResults.Created($"/api/candidate/{candidate.Id}", candidate);
    }

    public static async Task<IResult> UpdateCandidate(int id, Candidate inputCandidate, CandidateContext context)
    {
        var candidate = await context.Candidates.FindAsync(id);

        if (candidate is null) return TypedResults.NotFound();

        candidate.Name = inputCandidate.Name;
        candidate.Votes = inputCandidate.Votes;

        await context.SaveChangesAsync();

        return TypedResults.NoContent();
    }                                                   

    public static async Task<IResult> DeleteCandidate(int id, CandidateContext context)
    {
        if (await context.Candidates.FindAsync(id) is Candidate candidate)
        {
            context.Candidates.Remove(candidate);
            await context.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }
}

