using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace AdoVsEF
{
    public interface IService
    {
        IEnumerable<Sample> Get();
    }

    public class ServiceAdo : IService
    {
        private readonly DbConnection _dbConnection;

        public ServiceAdo(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Sample> Get()
        {
            DbCommand dbCommand = _dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT TOP (200000) Id, [Uid] FROM Demo;";

            _dbConnection.Open();
            DbDataReader dbDataReader = dbCommand.ExecuteReader();

            while(dbDataReader.Read())
            {
                yield return new Sample() { Id = (int)dbDataReader["Id"], Uid = (Guid)dbDataReader["Uid"] };
            }

            dbDataReader.Close();
            _dbConnection.Close();
        }
    }

    public class ServiceEF : IService
    {
        private readonly MyDbContext _dbContext;

        public ServiceEF(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Sample> Get()
        {
            foreach(Sample sample in _dbContext.Samples.Take(200000))
            {
                yield return sample;
            }

            _dbContext.ChangeTracker.Clear();
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Sample> Samples { get { return Set<Sample>(); } }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDb;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SampleConfiguration());
        }

        private class SampleConfiguration : IEntityTypeConfiguration<Sample>
        {
            public void Configure(EntityTypeBuilder<Sample> builder)
            {
                builder.ToTable("Demo");

                builder.Property(x => x.Uid)
                    .IsRequired();

                builder.HasKey("Id");
                builder.HasIndex(x => x.Uid)
                    .IsUnique();                
            }
        }

        public override int SaveChanges()
        {
            int rows = base.SaveChanges();
            ChangeTracker.Clear();
            return rows;
        }
    }
}
