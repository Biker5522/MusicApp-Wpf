using MusicApp.Models;
using MusicApp.Services;
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
    internal class CreateAlbumCommand : AsyncCommandBase
    {
        private readonly CreateAlbumViewModel _createAlbumViewModel;
        private readonly AlbumStore _albumStore;
        public CreateAlbumCommand(CreateAlbumViewModel createAlbumViewModel, AlbumStore albumStore)
        {
            _createAlbumViewModel = createAlbumViewModel;
            _albumStore = albumStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {

            Album album = new Album(
                 _createAlbumViewModel.Title,
                 _createAlbumViewModel.BandId,
                 _createAlbumViewModel.Year
             );
            try
            {
                await _albumStore.AddAlbum(album);
                MessageBox.Show("Successfuly added new Album.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Fail", "Error", MessageBoxButton.OK);
            }
        }
    }
}
