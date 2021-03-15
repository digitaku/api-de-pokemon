using System.Collections.Generic;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Services
{
    public interface ITypesServices
    {
        IEnumerable<Types> GetPokemons();
        Types GetPokemonByName(string name);
        void InsertPokemon(Types types);
        void EditPokemon(Types types);
        void DeletePokemon(Types types);
    }
}