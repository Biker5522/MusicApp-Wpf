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
    public class LoadSongsCommand : AsyncCommandBase
    {
        private readonly SongsListViewModel _viewModel;
        private readonly AlbumStore _albumStore;

        public LoadSongsCommand(SongsListViewModel viewModel, AlbumStore albumStore)
        {
            _viewModel = viewModel;
            _albumStore = albumStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _albumStore.Load();

                _viewModel.UpdateSongs(_albumStore.Songs);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load Genre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
