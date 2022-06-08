using MusicApp.Commands;
using MusicApp.Models;
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
    public class SongsListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<SongViewModel> _songs;
        public IEnumerable<SongViewModel> Songs => _songs;
        public ICommand CreateSongCommand { get; }
        public ICommand LoadSongsCommand { get; }
        public ICommand BackCommand { get; }
        public SongsListViewModel(NavigationService<CreateSongViewModel> createSongNavigationService, AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            _songs = new ObservableCollection<SongViewModel>();
            LoadSongsCommand = new LoadSongsCommand(this, albumStore);

            CreateSongCommand = new NavigateCommand<CreateSongViewModel>(createSongNavigationService);
            BackCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewModel);

        }
        public static SongsListViewModel ListViewModel(NavigationService<CreateSongViewModel> createSongNavigationService, AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            SongsListViewModel viewModel = new SongsListViewModel(createSongNavigationService, albumStore, mainMenuViewModel);
            viewModel.LoadSongsCommand.Execute(null);
            return viewModel;
        }
        public void UpdateSongs(IEnumerable<Song> songs)
        {
            _songs.Clear();

            foreach (Song song in songs)
            {
                SongViewModel songViewModel = new SongViewModel(song);

                _songs.Add(songViewModel);
            }
        }

    }
}
