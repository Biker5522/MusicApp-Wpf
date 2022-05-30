using MusicApp.Stores;
using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp.Commands
{
    public class LoadAlbumsCommand : AsyncCommandBase
    {
        private readonly AlbumListViewModel _viewModel;
        private readonly AlbumStore _albumStore;

        public LoadAlbumsCommand(AlbumListViewModel viewModel, AlbumStore albumStore)
        {
            _viewModel = viewModel;
            _albumStore = albumStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _albumStore.Load();

                _viewModel.UpdateAlbums(_albumStore.Albums);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load album.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
