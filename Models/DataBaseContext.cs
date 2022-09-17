namespace pifinal.Models;

using Microsoft.EntityFrameworkCore;

public class DataBaseContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataBaseContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
         if (!options.IsConfigured) 
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Disciplina> Disciplina { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        var disciplina = builder.Entity<Disciplina>();

        disciplina.ToTable("disciplinas");

    }
}