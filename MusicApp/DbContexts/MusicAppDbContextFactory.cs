using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DbContexts
{
    public class MusicAppDbContextFactory
    {
        private readonly string _connectionString;

        public MusicAppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MusicAppDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new MusicAppDbContext(options);
        }
    }
}
