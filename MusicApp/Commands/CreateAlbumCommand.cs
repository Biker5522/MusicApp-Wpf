using MusicApp.Services;
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
        private readonly Album _album;
        private readonly NavigationService _albumViewNavigationService;
        public CreateAlbumCommand(CreateAlbumViewModel createAlbumViewModel, NavigationService _albumViewNavigationService)
        {
            _createAlbumViewModel = createAlbumViewModel;
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
                await _album.MakeAlbum(album);
                _albumViewNavigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail", "Error", MessageBoxButton.OK);
            }



        }
    }
}
