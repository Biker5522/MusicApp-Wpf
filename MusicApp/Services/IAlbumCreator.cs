using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public interface IAlbumCreator
    {
        Task CreateAlbum(Album album);
    }
}
