using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class GenreViewModel
    {

        private readonly Genre _genre;
        public string Name => _genre.Name;

        public GenreViewModel(Genre genre)
        {
            _genre = genre;
        }
    }
}
