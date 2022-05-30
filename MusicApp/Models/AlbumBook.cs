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

        public AlbumBook(IAlbumProvider albumProvider, IAlbumCreator albumCreator)
        {
            _albumProvider = albumProvider;
            _albumCreator = albumCreator;
        }
        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await _albumProvider.GetAllAlbums();
        }

        public async Task AddAlbum(Album Album)
        {
            await _albumCreator.CreateAlbum(Album);
        }
    }
}
