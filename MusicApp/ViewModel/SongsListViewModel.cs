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
    public class SongsListViewModel : ViewModelBase
    {
        public ICommand LoadSongsCommand { get; }
        public ICommand BackCommand { get; }
        public SongsListViewModel(AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            BackCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewModel);

        }
        public static SongsListViewModel ListViewModel(AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            SongsListViewModel viewModel = new SongsListViewModel(albumStore, mainMenuViewModel);
            return viewModel;
        }
    }
}
