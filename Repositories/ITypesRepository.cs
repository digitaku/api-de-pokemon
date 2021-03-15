using System.Collections.Generic;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Repositories
{
    public interface ITypesRepository
    {
        IEnumerable<Types> GetTypes();
        Types GetTypesByName(string name);
        bool TypeExist(string name);
        void InsertTypes(Types types);
        void EditTypes(Types types, string name);
        void DeleteTypes(Types types);
    }
}