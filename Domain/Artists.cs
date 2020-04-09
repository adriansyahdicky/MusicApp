using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Domain
{
    public class Artists
    {
        [Key]
        public Int64 ArtistID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ArtistName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string AlbumName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string SampleURL { get; set; }
    }
}
