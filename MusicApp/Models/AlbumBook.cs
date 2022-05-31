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

        public AlbumBook(IAlbumProvider albumProvider, IAlbumCreator albumCreator, IBandProvider bandProvider, IBandCreator bandCreator)
        {
            _albumProvider = albumProvider;
            _albumCreator = albumCreator;
            _bandProvider = bandProvider;
            _bandCreator = bandCreator;

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
    }
}
