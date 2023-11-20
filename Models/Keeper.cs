using System.Collections.Generic;

namespace ZooManagement.Models
{
    public class Keeper
    {
        public int KeeperId { get; set; }
        public int Responsibility { get; set; }
        public string? Name { get; set; }

        public List<Animal> Animals { get; set; } = new();
    }
}