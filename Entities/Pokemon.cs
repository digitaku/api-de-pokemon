using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_de_pokemon.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        //Many TO Many
        public IEnumerable<Abilities> Abilities { get; set; }
        public IEnumerable<Types> Types { get; set; }
    }
}
