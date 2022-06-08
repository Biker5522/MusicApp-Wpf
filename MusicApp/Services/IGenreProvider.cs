using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public interface IGenreProvider
    {
        Task<IEnumerable<Genre>> GetAllGenres();
    }
}
