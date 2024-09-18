using Microsoft.EntityFrameworkCore;

public class VoterContext : DbContext
{
    public VoterContext(DbContextOptions<VoterContext> options)
        : base(options) { }

    public DbSet<Voter> Voters => Set<Voter>();
}