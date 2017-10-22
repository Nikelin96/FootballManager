using FootballManagerBL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManagerBL.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {

        }

        public EFContext()
            : this(ConfigurationManager.GetConnectionOptions())
        {
        }
    }
}
