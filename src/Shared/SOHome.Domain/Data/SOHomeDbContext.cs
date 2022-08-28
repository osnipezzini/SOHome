using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SOHome.Domain.Models;

namespace SOHome.Domain.Data;

public class SOHomeDbContext : DbContext
{
    private readonly ILogger<SOHomeDbContext> logger;

    public SOHomeDbContext(DbContextOptions optionsBuilder, ILogger<SOHomeDbContext> logger)
        : base(optionsBuilder)
    {
        this.logger = logger;
    }

    public DbSet<Person> People => Set<Person>();
    public DbSet<Product> Products => Set<Product>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
#endif
        optionsBuilder.LogTo(message => logger.LogDebug(message));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ToSnakeNames();
        // Declarando as sequencias
        modelBuilder.HasSequence("grid_seq");
        modelBuilder.HasSequence("person_code_seq");
        modelBuilder.HasSequence("product_code_seq");

        // Configuração da tabela de pessoas
        var personEntity = modelBuilder.Entity<Person>();
        personEntity.Property(x => x.Id)
            .HasDefaultValueSql("NEXTVAL('grid_seq')");
        personEntity.Property(x => x.Code)
            .HasDefaultValueSql("NEXTVAL('person_code_seq')");

        // Configuração da tabela de produtos
        var productEntity = modelBuilder.Entity<Product>();
        productEntity.Property(x => x.Id)
        .HasDefaultValueSql("NEXTVAL('grid_seq')");
        productEntity.Property(x => x.Code)
            .HasDefaultValueSql("NEXTVAL('product_code_seq')");
    }
}
