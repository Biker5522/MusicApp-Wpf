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
    public class SongCreator:ISongCreator
    {

        private readonly MusicAppDbContextFactory _dbContextFactory;

        public SongCreator(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateSong(Song Song)
        {
            if (await AlbumValidator(Song.AlbumId)) throw new Exception("zle");
            if (await BandValidator(Song.BandId)) throw new Exception("zle");
            if (await GenreValidator(Song.GenreId)) throw new Exception("zle");
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                SongDTO songDTO = ToSongDTO(Song);

                context.Songs.Add(songDTO);
                await context.SaveChangesAsync();
            }
        }
        private async Task<bool> BandValidator(string BandName)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                BandDTO BandDTO = await context.Bands.Where(b => b.Name == BandName).FirstOrDefaultAsync();

                if (BandDTO == null) return true;

                return false;
            }

        }
        private async Task<bool> GenreValidator(string GenreName)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                GenreDTO GenreDTO = await context.Genres.Where(b => b.Name == GenreName).FirstOrDefaultAsync();

                if (GenreDTO == null) return true;

                return false;
            }

        }
        private async Task<bool> AlbumValidator(string AlbumName)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                AlbumDTO AlbumDTO = await context.Albums.Where(b => b.Title == AlbumName).FirstOrDefaultAsync();

                if (AlbumDTO == null) return true;

                return false;
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
