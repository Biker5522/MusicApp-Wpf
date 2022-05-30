using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Stores
{
    public class AlbumStore
    {
        private readonly List<Album> _albums;
        private readonly Lazy<Task> _initializeLazy;
        private readonly AlbumBook _albumBook;


        public IEnumerable<Album> Albums => _albums;

        public AlbumStore(AlbumBook albumBook)
        {
            _albums = new List<Album>();
            _initializeLazy = new Lazy<Task>(Initialize);
            _albumBook = albumBook;

        }

        public async Task AddAlbum(Album Album)
        {
            await _albumBook.AddAlbum(Album);
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        private async Task Initialize()
        {
            IEnumerable<Album> albums = await _albumBook.GetAllAlbums();


            _albums.Clear();
            _albums.AddRange(albums);
        }
    }
}
