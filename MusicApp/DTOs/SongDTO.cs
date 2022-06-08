using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DTOs
{
    public class SongDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BandId { get; set; }
        public int Year{ get; set; }
        public string GenreId { get; set; }
        public string AlbumId { get; set; }
    }
}
