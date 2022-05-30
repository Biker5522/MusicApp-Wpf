using Microsoft.EntityFrameworkCore;
using MusicApp.DbContexts;
using MusicApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class AlbumProvider : IAlbumProvider
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public AlbumProvider(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<AlbumDTO> AlbumsDTOs = await context.Albums.ToListAsync();

                return AlbumsDTOs.Select(a => ToAlbum(a));
            }
        }

        private static Album ToAlbum(AlbumDTO a)
        {
            return new Album(a.Title, a.BandId, a.Year);
        }
    }
}
