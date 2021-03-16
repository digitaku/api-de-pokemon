using System.Collections.Generic;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Repositories
{
    public interface IAbilitiesRepository
    {
        IEnumerable<Abilities> GetAbilities();
        Abilities GetAbilitiesByName(string name);
        void InsertAbilities(Abilities abilities);
        void EditAbilities(Abilities abilities, string name);
        void DeleteAbilities(Abilities abilities);
        bool AbilityExist(string name);
    }
}