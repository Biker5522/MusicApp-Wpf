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
    public class CreateGenreViewModel:ViewModelBase
    {
        //Name of Genre
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        //Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateGenreViewModel(NavigationService<GenreListViewModel> genreViewNavigationService, AlbumStore albumStore)
        {
            SubmitCommand = new CreateGenreCommand(this, albumStore);
            CancelCommand = new NavigateCommand<GenreListViewModel>(genreViewNavigationService);
        }
    }
}
