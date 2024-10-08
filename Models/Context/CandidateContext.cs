using Microsoft.EntityFrameworkCore;

public class CandidateContext : DbContext
{
    public CandidateContext(DbContextOptions<CandidateContext> options)
        : base(options) { }

    public DbSet<Candidate> Candidates => Set<Candidate>();
}