using MusicApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands
{
    internal class CreateAlbumCommand : CommandBase
    {
        private readonly CreateAlbumViewModel _createAlbumViewModel;
        public CreateAlbumCommand(CreateAlbumViewModel createAlbumViewModel)
        {
            _createAlbumViewModel = createAlbumViewModel;
        }


        public override void Execute(object parameter)
        {
            Album album = new Album(
                _createAlbumViewModel.Title,
                _createAlbumViewModel.BandId,
                _createAlbumViewModel.Year
            );
        }
    }
}
