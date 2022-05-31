using MusicApp.Commands;
using MusicApp.Services;
using MusicApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModel
{
    public class GenreListViewModel : ViewModelBase
    {
        public ICommand LoadGenresCommand { get; }
        public ICommand BackCommand { get; }
        public GenreListViewModel(AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            BackCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewModel);

        }
        public static GenreListViewModel ListViewModel(AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            GenreListViewModel viewModel = new GenreListViewModel(albumStore, mainMenuViewModel);
            return viewModel;
        }
    }
}
