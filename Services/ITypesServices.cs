using System.Collections.Generic;
using api_de_pokemon.Entities;

namespace api_de_pokemon.Services
{
    public interface ITypesServices
    {
        IEnumerable<Types> GetTypes();
        Types GetTypesByName(string name);
        void InsertTypes(Types types);
        void EditTypes(Types types);
        void DeleteTypes(string name);
    }
}