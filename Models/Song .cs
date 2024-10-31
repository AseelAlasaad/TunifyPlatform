using TunifyPlatform.Models;

namespace TunifyPlatform.Controllers
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public TimeSpan SongDuration { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }

    }
}
