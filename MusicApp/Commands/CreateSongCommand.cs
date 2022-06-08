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
    public class CreateSongCommand :AsyncCommandBase
    {
        private readonly CreateSongViewModel _createSongViewModel;
        private readonly AlbumStore _albumStore;
        public CreateSongCommand(CreateSongViewModel createSongViewModel, AlbumStore albumStore)
        {
            _createSongViewModel = createSongViewModel;
            _albumStore = albumStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Song Song = new Song(
                 _createSongViewModel.Name,
                 _createSongViewModel.Year,
                 _createSongViewModel.BandId,
                 _createSongViewModel.AlbumId,
                 _createSongViewModel.GenreId
                 
             );
            try
            {
                await _albumStore.AddSong(Song);
                MessageBox.Show("Successfuly added new Song.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Fail", "Error", MessageBoxButton.OK);
            }
        }
    }
}
