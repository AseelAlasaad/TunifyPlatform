using TunifyPlatform.Controllers;

namespace TunifyPlatform.Models
{
    public class PlaylistSongs
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public Playlist Playlist { get; set; }
        public Song Song { get; set; }
    }
}
