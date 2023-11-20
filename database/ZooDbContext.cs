using Microsoft.EntityFrameworkCore;
using ZooManagement.Models;

namespace ZooManagement.database
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext()
        {

        }

        // Ett DbSet för varje tabell. 
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Keeper> Keepers { get; set; }
        public DbSet<Habitat> Habitats { get; set; }

        // OnConfiguring: 
        // Här lägger vi till vår connection string. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Kommer skapas en databas på servern med detta namnet.
            // Ibland vill man spara strängen som en fil också för att dölja den. 
            optionsBuilder.UseSqlServer("Server=USER-PC\\SQLEXPRESS;Database=ZooManager;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Delete behavior för djurskötare
            // - vad händer med dess djur när skötaren tas bort...
            modelBuilder.Entity<Keeper>()
           .HasMany(keeper => keeper.Animals) // en keeper kan ha många djur 
           .WithOne(anim => anim.Keeper) // och ett djur har en keeper 
           .OnDelete(DeleteBehavior.SetNull);
            // alla djur som skötaren var ansvarig för har en KeeperId som ska sättas till null om skötaren tas bort.

            // Delete behavior för habitat
            modelBuilder.Entity<Habitat>()
          .HasMany(habitat => habitat.Animals) // ett habitat kan ha många djur 
          .WithOne(animal => animal.Habitat) // och ett djur har ett habitat
          .OnDelete(DeleteBehavior.Restrict);

            // När vi seed:ar data måste vi ange id, dvs detta sköts inte automatiskt. 
            modelBuilder.Entity<Animal>()
                .HasData(

        new Animal { AnimalId = 1, Name = "Lion", Species = "Panthera leo", Age = 5, HabitatId = 1, KeeperId = 101 },
        new Animal { AnimalId = 2, Name = "Elephant", Species = "Loxodonta africana", Age = 10, HabitatId = 1, KeeperId = 102 },
        new Animal { AnimalId = 3, Name = "Giraffe", Species = "Giraffa camelopardalis", Age = 8, HabitatId = 1, KeeperId = 103 },
        new Animal { AnimalId = 4, Name = "Penguin", Species = "Spheniscidae", Age = 3, HabitatId = 4, KeeperId = 104 },
        new Animal { AnimalId = 5, Name = "Kangaroo", Species = "Macropodidae", Age = 6, HabitatId = 3, KeeperId = 105 },
        new Animal { AnimalId = 6, Name = "Tiger", Species = "Panthera tigris", Age = 7, HabitatId = 2, KeeperId = 101 },
        new Animal { AnimalId = 7, Name = "Panda", Species = "Ailuropoda melanoleuca", Age = 4, HabitatId = 2, KeeperId = 102 },
        new Animal { AnimalId = 8, Name = "Cheetah", Species = "Acinonyx jubatus", Age = 5, HabitatId = 1, KeeperId = 103 },
        new Animal { AnimalId = 9, Name = "Koala", Species = "Phascolarctos cinereus", Age = 2, HabitatId = 2, KeeperId = 105 },
        new Animal { AnimalId = 10, Name = "Gorilla", Species = "Gorilla", Age = 12, HabitatId = 2, KeeperId = 104 }
                );

            modelBuilder.Entity<Keeper>()
        .HasData(
            new Keeper { KeeperId = 101, Responsibility = 8, Name = "John Doe" },
            new Keeper { KeeperId = 102, Responsibility = 5, Name = "Jane Smith" },
            new Keeper { KeeperId = 103, Responsibility = 7, Name = "Bob Johnson" },
            new Keeper { KeeperId = 104, Responsibility = 6, Name = "Alice Brown" },
            new Keeper { KeeperId = 105, Responsibility = 9, Name = "Charlie Davis" },
            new Keeper { KeeperId = 106, Responsibility = 4, Name = "Emma White" },
            new Keeper { KeeperId = 107, Responsibility = 6, Name = "David Black" },
            new Keeper { KeeperId = 108, Responsibility = 8, Name = "Eva Green" },
            new Keeper { KeeperId = 109, Responsibility = 3, Name = "Frank Lee" },
            new Keeper { KeeperId = 110, Responsibility = 7, Name = "Grace Taylor" }
        );

            modelBuilder.Entity<Habitat>()
    .HasData(
        new Habitat { HabitatId = 1, Name = "Savannah", Biotope = "Grassland" },
        new Habitat { HabitatId = 2, Name = "Rainforest", Biotope = "Tropical" },
        new Habitat { HabitatId = 3, Name = "Desert", Biotope = "Arid" },
        new Habitat { HabitatId = 4, Name = "Arctic", Biotope = "Polar" },
        new Habitat { HabitatId = 5, Name = "Forest", Biotope = "Temperate" }
    );

        }
    }
}