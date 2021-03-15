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
            .AsNoTracking();
        }
        public Pokemon GetPokemonByName(string name)
        {
            return _db.Pokemons
            .Where(pokemon => pokemon.Name == name)
            .Include(pokemon => pokemon.Abilities)
            .Include(pokemon => pokemon.Types)
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

        public void EditPokemon(Pokemon pokemon)
        {
            try
            {
                _db.Pokemons.Update(pokemon);
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
                _db.Pokemons.Add(pokemon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}