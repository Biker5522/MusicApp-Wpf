using Microsoft.EntityFrameworkCore;
using MusicApp.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class DbContextFactory
    {

        public MusicAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source =musicApp.db").Options;
            return new MusicAppDbContext(options);
        }
    }
}
