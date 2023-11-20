using System.Collections.Generic;

namespace ZooManagement.Models
{
    public class Habitat
    {
        public int HabitatId { get; set; }
        public string? Name { get; set; }

        public List<Animal> Animals { get; set; } = new();
        public string Biotope { get; set; } = null!;
    }
}