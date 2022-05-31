using Microsoft.EntityFrameworkCore;
using MusicApp.DbContexts;
using MusicApp.DTOs;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class BandProvider : IBandProvider
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public BandProvider(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Band>> GetAllBands()
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<BandDTO> BandsDTOs = await context.Bands.ToListAsync();

                return BandsDTOs.Select(a => ToBand(a));
            }
        }

        private static Band ToBand(BandDTO a)
        {
            return new Band(a.Name, a.Year);
        }
    }
}
