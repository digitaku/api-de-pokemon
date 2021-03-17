using System.Collections.Generic;
using api_de_pokemon.Dto;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Services
{
    public interface IAbilitiesServices
    {
        IEnumerable<Abilities> GetAbilities();
        Abilities GetAbilitiesByName(string name);
        void InsertAbilities(Abilities abilities);
        void EditAbilities(Abilities abilities, string name);
        void DeleteAbilities(string name);
    }
}