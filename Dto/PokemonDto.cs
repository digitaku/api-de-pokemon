using System.Collections.Generic;

namespace api_de_pokemon.Dto
{
    public class PokemonDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        //Many TO Many
        public ICollection<AbilitiesDto> Abilities { get; set; }
        public ICollection<TypesDto> Types { get; set; }
    }
}