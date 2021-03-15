using System;
using System.Collections.Generic;
using System.Linq;
using api_de_pokemon.Context;
using api_de_pokemon.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_de_pokemon.Repositories.Implementation
{
    public class TypesRepository : ITypesRepository
    {
        private readonly ContextDb _context;
        public TypesRepository(ContextDb context)
        {
            this._context = context;
        }
        public IEnumerable<Types> GetTypes()
        {
            return _context.Types.AsNoTracking();
        }
        public Types GetTypesByName(string name)
        {
            return _context.Types.Where(type => type.Name == name).AsNoTracking().FirstOrDefault();
        }
        public void InsertTypes(Types type)
        {
            try
            {
                _context.Types.Add(type);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void EditTypes(Types type)
        {
            try
            {
                _context.Types.Update(type);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

        }
        public void DeleteTypes(Types type)
        {
            try
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}