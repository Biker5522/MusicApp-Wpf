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
    public class CreateGenreCommand : AsyncCommandBase
    {
        private readonly CreateGenreViewModel _createGenreViewModel;
        private readonly AlbumStore _albumStore;
        public CreateGenreCommand(CreateGenreViewModel createGenreViewModel, AlbumStore albumStore)
        {
            _createGenreViewModel = createGenreViewModel;
            _albumStore = albumStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Genre Genre = new Genre(
                 _createGenreViewModel.Name
             );
            try
            {
                await _albumStore.AddGenre(Genre);
                MessageBox.Show("Successfuly added new worker.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Fail", "Error", MessageBoxButton.OK);
            }
        }
    }
}

