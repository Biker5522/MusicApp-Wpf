using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModel
{
    public class AlbumListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AlbumViewModel> _albums;
        public IEnumerable<AlbumViewModel> Albums => _albums;
        public ICommand CreateAlbumCommand { get; }
        public AlbumListViewModel()
        {
            _albums = new ObservableCollection<AlbumViewModel>();
            _albums.Add(new AlbumViewModel(new Album("MODE DE VIE", "POD MOSTEM", 2019)));
            _albums.Add(new AlbumViewModel(new Album("Antagonista", "POD MOSTEM", 2015)));
        }
    }
}
