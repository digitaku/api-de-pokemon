using System.Collections.Generic;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Repositories
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetPokemons();
        IEnumerable<Pokemon> GetPokemonsByAbilities();
        IEnumerable<Pokemon> GetPokemonsByTypes();
        Pokemon GetPokemonByName(string name);
        void InsertPokemon(Pokemon pokemon);
        void EditPokemon(Pokemon pokemon);
        void DeletePokemon(Pokemon pokemon);

    }
}