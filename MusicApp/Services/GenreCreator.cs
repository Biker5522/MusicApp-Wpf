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
    public class GenreCreator : IGenreCreator
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public GenreCreator(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateGenre(Genre genre)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                GenreDTO genreDTO = ToGenreDTO(genre);

                context.Genres.Add(genreDTO);
                await context.SaveChangesAsync();
            }
        }


        private GenreDTO ToGenreDTO(Genre genre)
        {
            return new GenreDTO()
            {
                Name = genre.Name,
            };
        }
    }
}

