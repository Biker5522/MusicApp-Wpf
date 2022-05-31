using Microsoft.EntityFrameworkCore;
using MusicApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DbContexts
{
    public class MusicAppDbContext : DbContext
    {
        public MusicAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AlbumDTO> Albums { get; set; }
        public DbSet<BandDTO> Bands { get; set; }
    }
}
