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
            IBandProvider bandProvider = new BandProvider(_musicAppDbContextFactory);
            IBandCreator bandCreator = new BandCreator(_musicAppDbContextFactory);
            IGenreProvider genreProvider = new GenreProvider(_musicAppDbContextFactory);
            IGenreCreator genreCreator = new GenreCreator(_musicAppDbContextFactory);
            ISongProvider songProvider = new SongProvider(_musicAppDbContextFactory);
            ISongCreator songCreator = new SongCreator(_musicAppDbContextFactory);

            AlbumBook albumBook = new AlbumBook(albumProvider, albumCreator, bandProvider, bandCreator,genreProvider,genreCreator,songProvider,songCreator);
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
        //Band navigation
        private CreateAlbumViewModel CreateCreateAlbumViewModel()
        {
            return new CreateAlbumViewModel(new NavigationService<AlbumListViewModel>(_navigationStore, CreateAlbumViewModel), _albumStore);
        }
        private AlbumListViewModel CreateAlbumViewModel()
        {
            return AlbumListViewModel.ListViewModel(new NavigationService<CreateAlbumViewModel>(_navigationStore, CreateCreateAlbumViewModel), _albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        //Menu navigation
        private MainMenuViewModel CreateMainViewModel()
        {
            return new MainMenuViewModel(new NavigationService<AlbumListViewModel>(_navigationStore, CreateAlbumViewModel), new NavigationService<BandListViewModel>(_navigationStore, CreateBandViewModel), new NavigationService<SongsListViewModel>(_navigationStore, CreateSongViewModel), new NavigationService<GenreListViewModel>(_navigationStore, CreateGenreViewModel));
        }
        //Band navigation
        private BandListViewModel CreateBandViewModel()
        {
            return BandListViewModel.ListViewModel(new NavigationService<CreateBandViewModel>(_navigationStore, CreateCreateBandViewModel), _albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        private CreateBandViewModel CreateCreateBandViewModel()
        {
            return new CreateBandViewModel(new NavigationService<BandListViewModel>(_navigationStore, CreateBandViewModel), _albumStore);
        }
        //Song navigation
        private SongsListViewModel CreateSongViewModel()
        {
            return SongsListViewModel.ListViewModel(new NavigationService<CreateSongViewModel>(_navigationStore, CreateCreateSongViewModel), _albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        private CreateSongViewModel CreateCreateSongViewModel()
        {
            return new CreateSongViewModel(new NavigationService<SongsListViewModel>(_navigationStore, CreateSongViewModel), _albumStore);
        }

        //Genre navigation
        private GenreListViewModel CreateGenreViewModel()
        {
            return GenreListViewModel.ListViewModel(new NavigationService<CreateGenreViewModel>(_navigationStore, CreateCreateGenreViewModel), _albumStore, new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainViewModel));
        }
        private CreateGenreViewModel CreateCreateGenreViewModel()
        {
            return new CreateGenreViewModel(new NavigationService<GenreListViewModel>(_navigationStore, CreateGenreViewModel), _albumStore);
        }
    }
}
