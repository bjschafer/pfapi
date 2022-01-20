#nullable disable
using api.Models;

using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

#region Overrides of DbContext

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var classSeedData = Helpers.GetSeedData<Class>("Class");
        modelBuilder.Entity<Class>()
                    .HasData(classSeedData);
    }

#endregion

    public DbSet<Class> Class { get; set; }

    public DbSet<Spell> Spell { get; set; }
}
