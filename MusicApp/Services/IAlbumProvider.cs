using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Models;
namespace MusicApp.Services
{
    public interface IAlbumProvider
    {
        Task<IEnumerable<Album>> GetAllAlbums();
    }
}
