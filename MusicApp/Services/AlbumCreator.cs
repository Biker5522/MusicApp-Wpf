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
    public class AlbumCreator : IAlbumCreator
    {
        private readonly MusicAppDbContextFactory _dbContextFactory;

        public AlbumCreator(MusicAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateAlbum(Album album)
        {
            if (await AlbumValidator(album.BandId)) throw new Exception("zle");

            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                AlbumDTO albumDTO = ToAlbumDTO(album);

                context.Albums.Add(albumDTO);
                await context.SaveChangesAsync();
            }
        }
        private async Task<bool> AlbumValidator(string BandName)
        {
            using (MusicAppDbContext context = _dbContextFactory.CreateDbContext())
            {
                BandDTO BandDTO = await context.Bands.Where(b => b.Name == BandName).FirstOrDefaultAsync();

                if (BandDTO == null) return true;

                return false;
            }

        }

        private AlbumDTO ToAlbumDTO(Album album)
        {
            return new AlbumDTO()
            {
                Title = album.Title,
                BandId = album.BandId,
                Year = album.Year
            };
        }
    }
}
