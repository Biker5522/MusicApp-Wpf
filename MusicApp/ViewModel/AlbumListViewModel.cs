﻿using MusicApp.Commands;
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
    public class AlbumListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AlbumViewModel> _albums;
        public IEnumerable<AlbumViewModel> Albums => _albums;
        public ICommand CreateAlbumCommand { get; }
        public ICommand LoadAlbumsCommand { get; }
        public AlbumListViewModel(NavigationService<CreateAlbumViewModel> createAlbumNavigationService, AlbumStore albumStore)
        {
            _albums = new ObservableCollection<AlbumViewModel>();
            LoadAlbumsCommand = new LoadAlbumsCommand(this, albumStore);

            CreateAlbumCommand = new NavigateCommand<CreateAlbumViewModel>(createAlbumNavigationService);

        }
        public static AlbumListViewModel ListViewModel(NavigationService<CreateAlbumViewModel> createAlbumNavigationService, AlbumStore albumStore)
        {
            AlbumListViewModel viewModel = new AlbumListViewModel(createAlbumNavigationService, albumStore);
            viewModel.LoadAlbumsCommand.Execute(null);
            return viewModel;
        }

        public void UpdateAlbums(IEnumerable<Album> albums)
        {
            _albums.Clear();

            foreach (Album album in albums)
            {
                AlbumViewModel albumViewModel = new AlbumViewModel(album);

                _albums.Add(albumViewModel);
            }
        }
    }
}
