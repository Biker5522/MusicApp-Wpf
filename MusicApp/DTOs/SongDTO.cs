using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("BandDTO")]
        public string BandId { get; set; }
        public int Year{ get; set; }
        [ForeignKey("GenreDTO")]
        public string GenreId { get; set; }
        [ForeignKey("AlbumDTO")]
        public string AlbumId { get; set; }
    }
}
