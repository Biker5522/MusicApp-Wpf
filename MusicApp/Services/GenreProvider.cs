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
    public class GenreProvider:IGenreProvider
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public GenreProvider(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<GenreDTO> GenresDTOs = await context.Genres.ToListAsync();

                return GenresDTOs.Select(a => ToGenre(a));
            }
        }

        private static Genre ToGenre(GenreDTO a)
        {
            return new Genre(a.Name);
        }
    }
}
