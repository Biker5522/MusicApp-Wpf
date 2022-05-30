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
    public class BandListViewModel : ViewModelBase
    {
        public ICommand LoadBandsCommand { get; }
        public ICommand BackCommand { get; }
        public BandListViewModel(AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            BackCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewModel);

        }
        public static BandListViewModel ListViewModel(AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            BandListViewModel viewModel = new BandListViewModel(albumStore, mainMenuViewModel);
            return viewModel;
        }
    }
}
