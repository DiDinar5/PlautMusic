using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProvidingMusic.DataBase.Logger;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Context
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GroupMember>()
            //    .HasKey(gr => new { gr.FirstName, gr.LastName });


            modelBuilder
               .Entity<Album>()
               .HasMany(a => a.ListSongs)
               .WithOne()
               .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
               .Entity<Band>()
               .HasMany(b => b.Albums)
               .WithOne()
               .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
               .Entity<Band>()
               .HasMany(b => b.GroupMembers)
               .WithOne()
               .OnDelete(DeleteBehavior.ClientCascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name)
                .AddProvider(new LoggerProvider());
        });
    }
}
