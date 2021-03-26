using System.Collections.Generic;

namespace api_de_pokemon.Entities
{
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}