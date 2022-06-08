using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class AlbumBook
    {
        private readonly IAlbumProvider _albumProvider;
        private readonly IAlbumCreator _albumCreator;

        private readonly IBandProvider _bandProvider;
        private readonly IBandCreator _bandCreator;

        private readonly IGenreProvider _genreProvider;
        private readonly IGenreCreator _genreCreator;

        private readonly ISongProvider _songProvider;
        private readonly ISongCreator _songCreator;

        public AlbumBook(IAlbumProvider albumProvider, IAlbumCreator albumCreator, IBandProvider bandProvider, IBandCreator bandCreator, IGenreProvider genreProvider, IGenreCreator genreCreator, ISongProvider songProvider, ISongCreator songCreator)
        {
            _albumProvider = albumProvider;
            _albumCreator = albumCreator;
            _bandProvider = bandProvider;
            _bandCreator = bandCreator;
            _genreProvider = genreProvider;
            _genreCreator = genreCreator;
            _songProvider = songProvider;
            _songCreator = songCreator;

        }
        //Albums
        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await _albumProvider.GetAllAlbums();
        }

        public async Task AddAlbum(Album Album)
        {
            await _albumCreator.CreateAlbum(Album);
        }

        //Bands
        public async Task<IEnumerable<Band>> GetAllBands()
        {
            return await _bandProvider.GetAllBands();
        }

        public async Task AddBand(Band Band)
        {
            await _bandCreator.CreateBand(Band);
        }

        //Genres
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _genreProvider.GetAllGenres();
        }

        public async Task AddGenre(Genre Genre)
        {
            await _genreCreator.CreateGenre(Genre);
        }

        //Songs
        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return await _songProvider.GetAllSongs();
        }

        public async Task AddSong(Song Song)
        {
            await _songCreator.CreateSong(Song);
        }
    }
}
