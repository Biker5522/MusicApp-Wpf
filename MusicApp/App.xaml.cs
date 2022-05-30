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
        private readonly MusicAppDbContextFactory _musicAppDbContextFactory;
        public App()
        {
            _musicAppDbContextFactory = new MusicAppDbContextFactory(CONNECTION_STRING);
            IAlbumProvider albumProvider = new DatabaseAlbumProvider(_musicAppDbContextFactory);
            IAlbumCreator albumCreator = new DatabaseAlbumCreator(_musicAppDbContextFactory);
            AlbumBook albumBook = new AlbumBook(albumProvider, albumCreator);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (MusicAppDbContext dbContext = _musicAppDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

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
