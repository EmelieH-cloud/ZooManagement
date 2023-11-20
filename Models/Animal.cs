namespace ZooManagement.Models
{
    public class Animal
    {
        // Id, Namn, Art, Ålder, HabitatId, SkötareId
        public int AnimalId { get; set; }
        public Keeper? Keeper { get; set; } // ska vara nullable. Navigation property. 
        public int? KeeperId { get; set; }
        public int HabitatId { get; set; }

        public Habitat Habitat { get; set; } = null!; // navigation property.  
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public int Age { get; set; }
    }
}
