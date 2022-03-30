using DataAccess.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TheaterDbContext : IdentityDbContext<IdentityUser>
    {
        public TheaterDbContext(DbContextOptions<TheaterDbContext> options)
        : base(options)
        {
        }
        public DbSet<ShowEntity> ShowEntities { get; set; }
        public DbSet<TicketEntity> TicketEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=dbTheaterV3;Trusted_Connection=True;", b => b.MigrationsAssembly("LayersOnWeb"));
        }



    }
}
