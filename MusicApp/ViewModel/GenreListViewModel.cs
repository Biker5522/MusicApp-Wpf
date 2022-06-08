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
    public class GenreListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<GenreViewModel> _genres;
        public IEnumerable<GenreViewModel> Genres => _genres;
        public ICommand CreateGenreCommand { get; }
        public ICommand LoadGenresCommand { get; }
        public ICommand BackCommand { get; }
        public GenreListViewModel(NavigationService<CreateGenreViewModel> createGenreNavigationService, AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            _genres = new ObservableCollection<GenreViewModel>();
            LoadGenresCommand = new LoadGenresCommand(this, albumStore);

            CreateGenreCommand = new NavigateCommand<CreateGenreViewModel>(createGenreNavigationService);
            BackCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewModel);

        }
        public static GenreListViewModel ListViewModel(NavigationService<CreateGenreViewModel> createGenreNavigationService, AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            GenreListViewModel viewModel = new GenreListViewModel(createGenreNavigationService, albumStore, mainMenuViewModel);
            viewModel.LoadGenresCommand.Execute(null);
            return viewModel;
        }
        public void UpdateGenres(IEnumerable<Genre> genres)
        {
            _genres.Clear();

            foreach (Genre genre in genres)
            {
                GenreViewModel genreViewModel = new GenreViewModel(genre);

                _genres.Add(genreViewModel);
            }
        }
    }
}
