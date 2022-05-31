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
    public class BandCreator : IBandCreator
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public BandCreator(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateBand(Band band)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                BandDTO bandDTO = ToBandDTO(band);

                context.Bands.Add(bandDTO);
                await context.SaveChangesAsync();
            }
        }

        private BandDTO ToBandDTO(Band band)
        {
            return new BandDTO()
            {
                Name = band.Name,
                Year = band.Year
            };
        }
    }
}
