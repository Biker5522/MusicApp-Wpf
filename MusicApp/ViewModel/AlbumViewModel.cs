using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class AlbumViewModel : ViewModelBase
    {
        private readonly Album _album;
        public string Title => _album.Title;
        public string BandId => _album.BandId;
        public int Year => _album.Year;

        public AlbumViewModel(Album album)
        {
            _album = album;
        }
    }
}
