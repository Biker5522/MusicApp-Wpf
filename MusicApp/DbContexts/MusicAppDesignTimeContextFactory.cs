using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicApp.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DbContexts
{
    public class MusicAppDesignTimeContextFactory : IDesignTimeDbContextFactory<MusicAppDbContext>
    {
        public MusicAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=musicApp.db").Options;
            return new MusicAppDbContext(options);
        }
    }
}
