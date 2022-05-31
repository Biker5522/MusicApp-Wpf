using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public interface IBandCreator
    {
        Task CreateBand(Band band);
    }
}
