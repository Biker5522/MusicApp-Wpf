using MusicApp.DbContexts;
using MusicApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class DatabaseAlbumCreator : IAlbumCreator
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;
        public DatabaseAlbumCreator(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAlbum(Album album)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                AlbumDTO albumDTO = ToAlbumDTO(album);
                context.Albums.Add(albumDTO);
                await context.SaveChangesAsync();
            }
        }

        private AlbumDTO ToAlbumDTO(Album album)
        {
            return new AlbumDTO()
            {
                Title = album.Title,
                BandId = album.BandId,
                Year = album.Year,
            };

        }
    }
}
