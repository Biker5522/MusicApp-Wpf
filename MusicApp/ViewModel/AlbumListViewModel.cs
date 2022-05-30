using MusicApp.Commands;
using MusicApp.Services;
using MusicApp.Stores;
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
        public ICommand LoadAlbumsCommand { get; }
        public AlbumListViewModel(NavigationService createAlbumNavigationService)
        {
            _albums = new ObservableCollection<AlbumViewModel>();
            LoadAlbumsCommand = new LoadAlbumsCommand(this);

            CreateAlbumCommand = new NavigateCommand<CreateAlbumCommand>(createAlbumNavigationService);

        }
        public static AlbumListViewModel ListViewModel(NavigationService createAlbumNavigationService)
        {
            AlbumListViewModel viewModel = new AlbumListViewModel(createAlbumNavigationService);
            viewModel.LoadAlbumsCommand.Execute(null);
            return viewModel;
        }

        private void UpdateAlbums()
        {
            _albums.Clear();
        }
    }
}
