using System;
using System.Collections.Generic;
using System.Linq;
using api_de_pokemon.Context;
using api_de_pokemon.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_de_pokemon.Repositories.Implementation
{
    public class AbilitiesRepository : IAbilitiesRepository
    {
        private readonly ContextDb _db;
        public AbilitiesRepository(ContextDb context)
        {
            this._db = context;
        }
        public IEnumerable<Abilities> GetAbilities()
        {
            return _db.Abilities.AsNoTracking();
        }

        public Abilities GetAbilitiesByName(string name)
        {
            return _db.Abilities.Where(ability => ability.Name == name).AsNoTracking().FirstOrDefault();
        }
        public void DeleteAbilities(Abilities ability)
        {
            try
            {
                _db.Abilities.Remove(ability);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw ex;
            }
        }

        public void EditAbilities(Abilities ability)
        {
            try
            {
                _db.Abilities.Update(ability);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw ex;
            }
        }


        public void InsertAbilities(Abilities ability)
        {
            try
            {
                _db.Abilities.Add(ability);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}