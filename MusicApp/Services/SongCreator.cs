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
    public class SongCreator:ISongCreator
    {

        private readonly MusicAppDbContextFactory _dbContextFactory;

        public SongCreator(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateSong(Song Song)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                SongDTO songDTO = ToSongDTO(Song);

                context.Songs.Add(songDTO);
                await context.SaveChangesAsync();
            }
        }

        private SongDTO ToSongDTO(Song song)
        {
            return new SongDTO()
            {
                Name = song.Name,
                Year = song.Year,
                BandId = song.BandId,
                AlbumId = song.AlbumId,
                GenreId = song.GenreId,

            };
        }
    }
}
