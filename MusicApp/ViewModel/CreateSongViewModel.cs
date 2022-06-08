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
    public class CreateSongViewModel:ViewModelBase
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
        //Band
        private string _bandId;
        public string BandId
        {
            get { return _bandId; }
            set { _bandId = value; OnPropertyChanged(nameof(BandId)); }
        }
        //Album
        private string _albumId;
        public string AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; OnPropertyChanged(nameof(AlbumId)); }
        }

        //Genre
        private string _genreId;
        public string GenreId
        {
            get { return _genreId; }
            set { _genreId = value; OnPropertyChanged(nameof(GenreId)); }
        }

        //Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateSongViewModel(NavigationService<SongsListViewModel> songViewNavigationService, AlbumStore albumStore)
        {
            SubmitCommand = new CreateSongCommand(this, albumStore);
            CancelCommand = new NavigateCommand<SongsListViewModel>(songViewNavigationService);
        }
    }
}
