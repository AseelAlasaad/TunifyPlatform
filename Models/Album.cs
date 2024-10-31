using TunifyPlatform.Controllers;

namespace TunifyPlatform.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public ICollection<Song> Songs { get; set; }

    }
}
