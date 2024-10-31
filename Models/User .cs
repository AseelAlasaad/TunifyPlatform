using TunifyPlatform.Models;

namespace TunifyPlatform.Controllers
{
    public class User
    {

      
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
   
            public ICollection<Playlist> Playlists { get; set; }
            public DateTime JoinDate { get; set; }
            public int SubscriptionId { get; set; }
            public Subscription Subscription { get; set; }


    }
}
