using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands
{
    public class LoadAlbumsCommand : AsyncCommandBase
    {
        private readonly AlbumListViewModel _viewModel;

        public LoadAlbumsCommand(AlbumListViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {

        }
    }
}
