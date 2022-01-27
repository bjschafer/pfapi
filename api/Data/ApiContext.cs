#nullable disable
using api.Models.Database;

using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public DbSet<Class>      Class      { get; set; }
    public DbSet<Spell>      Spell      { get; set; }
    public DbSet<Descriptor> Descriptor { get; set; }

#region Overrides of DbContext

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ensure that certain fixed data (like class names) is always seeded into
        // the database. Note that even autogenerated IDs must be set on the objects therein
        var classSeedData = Helpers.GetSeedData<Class>("Class");
        modelBuilder.Entity<Class>()
                    .HasData(classSeedData);
        var descriptorseedData = Helpers.GetSeedData<Descriptor>("Descriptor");
        modelBuilder.Entity<Descriptor>()
                    .HasData(descriptorseedData);
    }

#endregion
}
