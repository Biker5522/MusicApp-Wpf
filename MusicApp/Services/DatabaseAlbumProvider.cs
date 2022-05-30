using Microsoft.EntityFrameworkCore;
using MusicApp.DbContexts;
using MusicApp.DTOs;
using MusicApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class DatabaseAlbumProvider : IAlbumProvider
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;
        public DatabaseAlbumProvider(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<AlbumDTO> albumDTOs = await context.Albums.ToListAsync();
                return albumDTOs.Select(r => new Album(r.Title, r.BandId, r.Year));
            }
        }
    }
}
