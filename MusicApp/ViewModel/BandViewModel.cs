using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class BandViewModel
    {
        private readonly Band _band;
        public string Name => _band.Name;
        public int Year => _band.Year;

        public BandViewModel(Band band)
        {
            _band = band;
        }
    }
}
