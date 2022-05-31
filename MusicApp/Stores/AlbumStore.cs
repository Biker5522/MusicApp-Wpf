﻿using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Stores
{
    public class AlbumStore
    {
        private readonly List<Album> _albums;
        private readonly List<Band> _bands;
        private readonly Lazy<Task> _initializeLazy;
        private readonly AlbumBook _albumBook;


        public IEnumerable<Album> Albums => _albums;
        public IEnumerable<Band> Bands => _bands;

        public AlbumStore(AlbumBook albumBook)
        {
            _albums = new List<Album>();
            _initializeLazy = new Lazy<Task>(Initialize);
            _albumBook = albumBook;
            _bands = new List<Band>();

        }

        public async Task AddAlbum(Album Album)
        {
            await _albumBook.AddAlbum(Album);
        }
        public async Task AddBand(Band Band)
        {
            await _albumBook.AddBand(Band);
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        private async Task Initialize()
        {
            IEnumerable<Album> albums = await _albumBook.GetAllAlbums();
            _albums.Clear();
            _albums.AddRange(albums);

            IEnumerable<Band> bands = await _albumBook.GetAllBands();
            _bands.Clear();
            _bands.AddRange(bands);
        }
    }
}
