using MusicApp.Stores;
using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands
{
    public class LoadBandsCommand : AsyncCommandBase
    {
        private readonly BandListViewModel _viewModel;
        private readonly AlbumStore _albumStore;

        public LoadBandsCommand(BandListViewModel viewModel, AlbumStore albumStore)
        {
            _viewModel = viewModel;
            _albumStore = albumStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {

        }
    }
}

