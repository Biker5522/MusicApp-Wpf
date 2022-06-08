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
    public class SongProvider:ISongProvider
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public SongProvider(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SongDTO> SongsDTOs = await context.Songs.ToListAsync();

                return SongsDTOs.Select(a => ToSong(a));
            }
        }

        private static Song ToSong(SongDTO a)
        {
            return new Song(a.Name, a.Year,a.BandId,a.AlbumId,a.GenreId);
        }
    }
}
