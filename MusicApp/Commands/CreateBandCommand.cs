using MusicApp.Models;
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
    public class CreateBandCommand : AsyncCommandBase
    {
        private readonly CreateBandViewModel _createBandViewModel;
        private readonly AlbumStore _albumStore;
        public CreateBandCommand(CreateBandViewModel createAlbumViewModel, AlbumStore albumStore)
        {
            _createBandViewModel = createAlbumViewModel;
            _albumStore = albumStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Band Band = new Band(
                 _createBandViewModel.Name,
                 _createBandViewModel.Year
             );
            try
            {
                await _albumStore.AddBand(Band);
                MessageBox.Show("Successfuly added new worker.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Fail", "Error", MessageBoxButton.OK);
            }
        }
    }
}
