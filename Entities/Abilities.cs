using System.Collections.Generic;

namespace api_de_pokemon.Entities
{
    public class Abilities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EffectDescription { get; set; }
        public bool IsHidden { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}