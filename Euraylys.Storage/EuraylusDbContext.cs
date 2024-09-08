using Euraylus.Storage.Sets;
using Microsoft.EntityFrameworkCore;

namespace Euraylus.Storage;

public class EuraylusDbContext : DbContext {
    public DbSet<UserDataSet> UserDataSet { get; set; }
    public DbSet<ChannelDataSet> ChannelDataSet { get; set; }

    public EuraylusDbContext( DbContextOptions<EuraylusDbContext> options ) : base( options ) {
    }
}
