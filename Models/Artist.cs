﻿namespace TunifyPlatform.Controllers
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Bio { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
