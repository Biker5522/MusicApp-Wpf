using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class SongViewModel
    {
        private readonly Song _song;
        public string Name => _song.Name;
        public int Year => _song.Year;
        public string AlbumId => _song.AlbumId;
        public string GenreId => _song.GenreId;
        public string BandId => _song.BandId;

        public SongViewModel(Song song)
        {
            _song = song;
        }
    }
}
