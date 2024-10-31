using System.ComponentModel.DataAnnotations.Schema;
using TunifyPlatform.Controllers;

namespace TunifyPlatform.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Type { get; set; }
        
        public double Price { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
