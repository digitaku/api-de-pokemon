using System.Collections.Generic;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Services
{
    public interface IPokemonServices
    {
        IEnumerable<Pokemon> GetPokemons();
        IEnumerable<Pokemon> GetPokemonsByAbilities(string name);
        IEnumerable<Pokemon> GetPokemonsByTypes(string name);
        Pokemon GetPokemonByName(string name);
        void InsertPokemon(Pokemon pokemon);
        void EditPokemon(Pokemon pokemon);
        void DeletePokemon(string name);
    }
}