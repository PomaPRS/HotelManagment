using System.Data.Entity;
using Hotel.Database.Model;

namespace Hotel.Database
{
    public class HotelContext : DbContext
    {
        public HotelContext() 
            : base("Data Source=(LocalDb)\\v11.0;Initial Catalog=HotelDatabase;Integrated Security=True")
        {
        }

        public DbSet<Model.Hotel> Hotels { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<PopularRoom> PopularRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasRequired(x => x.Hotel)
                .WithMany(x => x.Workers);

            modelBuilder.Entity<Worker>()
                .HasRequired(x => x.Position)
                .WithMany(x => x.Workers);

            modelBuilder.Entity<Reservation>()
                .HasRequired(x => x.Room)
                .WithMany(x => x.Reservations);

            modelBuilder.Entity<Reservation>()
                .HasRequired(x => x.Visitor)
                .WithMany(x => x.Reservations);

            modelBuilder.Entity<Room>()
                .HasRequired(x => x.Hotel)
                .WithMany(x => x.Rooms);

            base.OnModelCreating(modelBuilder);
        }
    }
}