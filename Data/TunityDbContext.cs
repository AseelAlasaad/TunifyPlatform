using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Controllers;
using TunifyPlatform.Models;

namespace TunifyPlatform.Data
{
    public class TunityDbContext: DbContext
    {
        public  TunityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
       
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Playlist>()
               .HasOne(p => p.User)
               .WithMany(u => u.Playlists)
               .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            // Define relationships
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs) // Assuming Album has a Songs collection
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            // Define composite key for PlaylistSongs
            modelBuilder.Entity<PlaylistSongs>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId).OnDelete(DeleteBehavior.Restrict);

        


            modelBuilder.Entity<Subscription>().HasData(
               new Subscription { Id = 1, Type = "Free", Price = 0.0 },
               new Subscription { Id = 2, Type = "Premium", Price = 8.9 }
           );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Email = "admin@gmail.com", JoinDate = DateTime.Now, SubscriptionId = 1 },
                new User { Id = 2,Username = "Aseel", Email = "aseelalasaad@gmail.com", JoinDate = DateTime.Now.AddDays(-10), SubscriptionId = 2 }
            );


            // Seed data in dependency order
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Mark", Bio = "Good Singer" },
                new Artist { Id = 2, Name = "Justin", Bio = "Good Singer" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, AlbumName = "Album 1" },
                new Album { Id = 2, AlbumName = "Album 2" }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, SongDuration = TimeSpan.FromMinutes(3), Type = "hip-hop music" },
                new Song { Id = 2, Title = "Song 2", ArtistId = 1, AlbumId = 2, SongDuration = TimeSpan.FromMinutes(4), Type = "Rock music" }
            );


        }
        public DbSet<TunifyPlatform.Models.Subscription> Subscription { get; set; } = default!;

    }
}
