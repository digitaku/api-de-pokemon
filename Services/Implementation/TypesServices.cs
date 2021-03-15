using System;
using System.Collections.Generic;
using api_de_pokemon.Entities;
using api_de_pokemon.Repositories;
using api_de_pokemon.Exceptions;

namespace api_de_pokemon.Services.Implementation
{
    public class TypesServices : ITypesServices
    {
        private readonly ITypesRepository _repository;

        public TypesServices(ITypesRepository repository)
        {
            this._repository = repository;
        }
        public Types GetTypesByName(string name)
        {
            return _repository.GetTypesByName(name);
        }

        public IEnumerable<Types> GetTypes()
        {
            return _repository.GetTypes();
        }
        public void DeleteTypes(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Type require a name.");
            }
            Types typeExist = _repository.GetTypesByName(name);
            if (typeExist == null)
            {
                throw new NotFoundException($"Type with name {name} not found.");
            }
            try
            {
                _repository.DeleteTypes(typeExist);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);
            }
        }

        public void EditTypes(Types types)
        {
            if (types == null || types.Name == null)
            {
                throw new BadRequestException("Type require a name.");
            }
            Types typeExist = _repository.GetTypesByName(types.Name);
            if (typeExist == null)
            {
                throw new NotFoundException($"Type with name {types.Name} not found.");

            }
            try
            {
                typeExist.Name = types.Name;
                typeExist.Color = types.Color;
                _repository.DeleteTypes(typeExist);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);

            }
        }

        public void InsertTypes(Types types)
        {
            if (types == null || types.Name == null)
            {
                throw new BadRequestException("Type require a name.");
            }
            Types typeExist = _repository.GetTypesByName(types.Name);
            if (typeExist != null)
            {
                throw new AlreadyExistException($"Type with name {types.Name} already exist.");
            }
            try
            {
                _repository.InsertTypes(types);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);

            }
        }
    }
}