using Microsoft.EntityFrameworkCore;
using MusicApp.DbContexts;
using MusicApp.Models;
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
        private const string CONNECTION_STRING = "Data Source = musicApp.db";
        private readonly NavigationStore _navigationStore;
        private readonly AlbumStore _albumStore;
        private readonly MusicAppDbContextFactory _musicAppDbContextFactory;
        public App()
        {
            _musicAppDbContextFactory = new MusicAppDbContextFactory(CONNECTION_STRING);
            IAlbumProvider albumProvider = new AlbumProvider(_musicAppDbContextFactory);
            IAlbumCreator albumCreator = new AlbumCreator(_musicAppDbContextFactory);
            AlbumBook albumBook = new AlbumBook(albumProvider, albumCreator);
            _albumStore = new AlbumStore(albumBook);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (MusicAppDbContext dbContext = _musicAppDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateMainViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private CreateAlbumViewModel CreateCreateAlbumViewModel()
        {
            return new CreateAlbumViewModel(new NavigationService<AlbumListViewModel>(_navigationStore, CreateAlbumViewModel), _albumStore);
        }

        private AlbumListViewModel CreateAlbumViewModel()
        {
            return AlbumListViewModel.ListViewModel(new NavigationService<CreateAlbumViewModel>(_navigationStore, CreateCreateAlbumViewModel), _albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        private MainMenuViewModel CreateMainViewModel()
        {
            return new MainMenuViewModel(new NavigationService<AlbumListViewModel>(_navigationStore, CreateAlbumViewModel), new NavigationService<BandListViewModel>(_navigationStore, CreateBandViewModel), new NavigationService<SongsListViewModel>(_navigationStore, CreateSongViewModel), new NavigationService<GenreListViewModel>(_navigationStore, CreateGenreViewModel));
        }
        private BandListViewModel CreateBandViewModel()
        {
            return BandListViewModel.ListViewModel(_albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        private SongsListViewModel CreateSongViewModel()
        {
            return SongsListViewModel.ListViewModel(_albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        private GenreListViewModel CreateGenreViewModel()
        {
            return GenreListViewModel.ListViewModel(_albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
    }
}
