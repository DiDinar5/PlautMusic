using Microsoft.EntityFrameworkCore;
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
        
        
        //OnConfigure
    }
}
