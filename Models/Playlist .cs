using TunifyPlatform.Models;

namespace TunifyPlatform.Controllers
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Foreign key for User
        public int UserId { get; set; }

        // Navigation property for User
        public User User { get; set; }
        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }
    }
}
