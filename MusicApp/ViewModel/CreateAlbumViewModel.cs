using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModel
{
    public class CreateAlbumViewModel : ViewModelBase
    {
        //Title of Album
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        //Band
        private string _bandId;
        public string BandId
        {
            get { return _bandId; }
            set { _bandId = value; OnPropertyChanged(nameof(BandId)); }
        }

        //Year of Publishing
        private int _year;
        public int Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged(nameof(Year)); }
        }

        //Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateAlbumViewModel()
        {

        }
    }
}
