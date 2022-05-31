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
    public class CreateBandViewModel : ViewModelBase
    {
        //Title of Album
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        //Year of Estabilishment
        private int _year;
        public int Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged(nameof(Year)); }
        }

        //Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateBandViewModel(NavigationService<BandListViewModel> bandViewNavigationService, AlbumStore albumStore)
        {
            SubmitCommand = new CreateBandCommand(this, albumStore);
            CancelCommand = new NavigateCommand<BandListViewModel>(bandViewNavigationService);
        }
    }
}
