using MusicApp.Commands;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ICommand AlbumCommand { get; }
        public ICommand BandCommand { get; }
        public ICommand GenresCommand { get; }
        public ICommand SongsCommand { get; }
        public MainMenuViewModel(NavigationService<AlbumListViewModel> ManageAlbumsNavigationService, NavigationService<BandListViewModel> ManageBandNavigationService, NavigationService<SongsListViewModel> ManageSongsNavigationService, NavigationService<GenreListViewModel> ManageGenreNavigationService)
        {
            AlbumCommand = new NavigateCommand<AlbumListViewModel>(ManageAlbumsNavigationService);
            BandCommand = new NavigateCommand<BandListViewModel>(ManageBandNavigationService);
            GenresCommand = new NavigateCommand<GenreListViewModel>(ManageGenreNavigationService);
            SongsCommand = new NavigateCommand<SongsListViewModel>(ManageSongsNavigationService);
        }
    }
}
