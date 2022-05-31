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
    public class BandListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<BandViewModel> _bands;
        public IEnumerable<BandViewModel> Bands => _bands;
        public ICommand CreateBandCommand { get; }
        public ICommand LoadBandsCommand { get; }
        public ICommand BackCommand { get; }
        public BandListViewModel(NavigationService<CreateBandViewModel> createBandNavigationService, AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            _bands = new ObservableCollection<BandViewModel>();
            LoadBandsCommand = new LoadBandsCommand(this, albumStore);

            CreateBandCommand = new NavigateCommand<CreateBandViewModel>(createBandNavigationService);
            BackCommand = new NavigateCommand<MainMenuViewModel>(mainMenuViewModel);

        }
        public static BandListViewModel ListViewModel(NavigationService<CreateBandViewModel> createBandNavigationService, AlbumStore albumStore, NavigationService<MainMenuViewModel> mainMenuViewModel)
        {
            BandListViewModel viewModel = new BandListViewModel(createBandNavigationService, albumStore, mainMenuViewModel);
            viewModel.LoadBandsCommand.Execute(null);
            return viewModel;
        }
        public void UpdateBands(IEnumerable<Band> bands)
        {
            _bands.Clear();

            foreach (Band band in bands)
            {
                BandViewModel bandViewModel = new BandViewModel(band);

                _bands.Add(bandViewModel);
            }
        }
    }
}
