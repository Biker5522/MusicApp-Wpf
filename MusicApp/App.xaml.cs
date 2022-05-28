using MusicApp.Services;
using MusicApp.Stores;
using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateAlbumViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private CreateAlbumViewModel CreateCreateAlbumViewModel()
        {
            return new CreateAlbumViewModel(new NavigationService(_navigationStore, CreateAlbumViewModel));
        }

        private AlbumListViewModel CreateAlbumViewModel()
        {
            return new AlbumListViewModel(new NavigationService(_navigationStore, CreateCreateAlbumViewModel));
        }
    }
}
