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

        public MainMenuViewModel(NavigationService<AlbumListViewModel> ManageAlbumsNavigationService, NavigationService<BandListViewModel> ManageBandNavigationService/*, NavigationService<EquipListingViewModel> ManageEquipNavigationService, NavigationService<ReservationListingViewModel> ManageReservationsNavigationService*/)
        {
            AlbumCommand = new NavigateCommand<AlbumListViewModel>(ManageAlbumsNavigationService);
            BandCommand = new NavigateCommand<BandListViewModel>(ManageBandNavigationService);
            //GenresCommand = new NavigateCommand<EquipListingViewModel>(ManageEquipNavigationService);
            //SongsCommand = new NavigateCommand<ReservationListingViewModel>(ManageReservationsNavigationService);
        }
    }
}
