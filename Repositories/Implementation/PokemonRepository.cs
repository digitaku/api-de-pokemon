using System;
using System.Collections.Generic;
using System.Linq;
using api_de_pokemon.Context;
using api_de_pokemon.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_de_pokemon.Repositories.Implementation
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ContextDb _db;

        public PokemonRepository(ContextDb context)
        {
            this._db = context;
        }
        public IEnumerable<Pokemon> GetPokemons()
        {
            return _db.Pokemons.
            Include(pokemon => pokemon.Abilities)
            .Include(pokemon => pokemon.Types)
            .AsSingleQuery()
            .AsNoTracking();
        }
        public Pokemon GetPokemonByName(string name)
        {
            return _db.Pokemons
            .Where(pokemon => pokemon.Name == name)
            .Include(pokemon => pokemon.Abilities)
            .Include(pokemon => pokemon.Types)
            .AsSingleQuery()
            .AsNoTracking()
            .FirstOrDefault();
        }

        public IEnumerable<Pokemon> GetPokemonsByAbilities(string name)
        {
            //
            return _db.Pokemons
            .Include(pokemon => pokemon.Abilities)
            .Include(pokemon => pokemon.Types)
            .AsNoTracking();
        }

        public IEnumerable<Pokemon> GetPokemonsByTypes(string name)
        {
            //
            return _db.Pokemons
            .Include(pokemon => pokemon.Abilities)
            .Include(pokemon => pokemon.Types)

            .AsNoTracking();
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            try
            {
                _db.Pokemons.Remove(pokemon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void EditPokemon(Pokemon pokemon, string name)
        {
            try
            {
                var pokemonUpdate =
                 _db.Pokemons
                 .Include(p => p.Types)
                 .Include(p => p.Abilities)
                 .AsSingleQuery()
                 .FirstOrDefault(pokemon => pokemon.Name == name);

                //propriedades que serão alteradas
                pokemonUpdate.Name = pokemon.Name;
                pokemonUpdate.Alias = pokemon.Alias;
                pokemonUpdate.Description = pokemon.Description;
                pokemonUpdate.Color = pokemon.Color;
                pokemonUpdate.ImageUrl = pokemon.ImageUrl;
                pokemonUpdate.Height = pokemon.Height;
                pokemonUpdate.Weight = pokemon.Weight;

                //alteração dos relacionamentos
                /**
                 * Verificar se os nome são iguais
                 * Remover todos os itens das listas
                 * Deve buscar os novos itens usando o nome passado nas lista em pokemon 
                 * Adicionar esse item caso encontrado.
                 */
                //remove tipo
                foreach(var types in pokemonUpdate.Types) 
                {
                    if(pokemon.Types.Select(t => t.Name == types.Name) == null)
                    {
                        pokemonUpdate.Types.Remove(types);
                    }
                    else 
                    {
                        pokemon.Types.Remove(pokemon.Types.FirstOrDefault(t =>t.Name ==types.Name));
                    }
                }
                //adiciona novo tipo
                foreach(var type in pokemon.Types) 
                {
                    var typeExist = _db.Types
                        .AsNoTracking()
                        .FirstOrDefault(t => t.Name == type.Name);
                    if(typeExist != null) 
                    {
                        pokemonUpdate.Types.Add(typeExist);
                    }
                }
                //remove tipo
                foreach(var ability in pokemonUpdate.Abilities) 
                {
                    if (pokemon.Abilities.Select(a=>a.Name == ability.Name) == null) 
                    {
                        pokemonUpdate.Abilities.Remove(ability);
                    }
                    else
                    {
                        pokemon.Abilities.Remove(pokemon.Abilities.FirstOrDefault(a =>a.Name == ability.Name));
                    }
                }
                //adiciona tipo
                foreach(var ability in pokemon.Abilities)
                {
                    var abilityExist = _db.Abilities
                        .AsNoTracking()
                        .FirstOrDefault(a => a.Name == ability.Name);
                    if(abilityExist != null)
                    {
                        pokemonUpdate.Abilities.Add(abilityExist);
                    }
                }

                //salvar as alterações
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void InsertPokemon(Pokemon pokemon)
        {
            try
            {
                var pokemonTypes = new List<Types>();
                var pokemonAbilities = new List<Abilities>();

                foreach (var item in pokemon.Abilities)
                {
                    pokemonAbilities.Add(
                        _db.Abilities
                        .Where(ability => ability.Name == item.Name)
                        .AsNoTracking()
                        .FirstOrDefault()
                    );

                }

                foreach (var item in pokemon.Types)
                {
                    pokemonTypes.Add(
                        _db.Types.Where(types => types.Name == item.Name)
                        .AsNoTracking()
                        .FirstOrDefault()
                    );

                }
                pokemon.Abilities = pokemonAbilities;
                pokemon.Types = pokemonTypes;
                _db.Pokemons.Update(pokemon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public bool PokemonExist(string name)
        {
            return _db.Pokemons.Where(pokemon => pokemon.Name == name).AsNoTracking().FirstOrDefault() != null;
        }
    }
}