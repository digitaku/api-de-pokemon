using System;
using System.Collections.Generic;
using api_de_pokemon.Dto;
using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
using api_de_pokemon.Repositories;
using AutoMapper;

namespace api_de_pokemon.Services.Implementation
{
    public class AbilitiesServices : IAbilitiesServices
    {
        private readonly IAbilitiesRepository _repository;
        public AbilitiesServices(IAbilitiesRepository repository)
        {
            this._repository = repository;
        }
        public void DeleteAbilities(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Ability require a name.");
            }
            if (!_repository.AbilityExist(name))
            {
                throw new NotFoundException($"Ability with name {name} not found.");
            }
            try
            {
                _repository.DeleteAbilities(_repository.GetAbilitiesByName(name));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);
            }
        }

        public void EditAbilities(Abilities ability, string name)
        {
            if (ability == null || ability.Name == null || name == null)
            {
                throw new BadRequestException("Ability require a name.");
            }
            if (!_repository.AbilityExist(name))
            {
                throw new NotFoundException($"Ability with name {ability.Name} not found.");
            }
            try
            {
                _repository.EditAbilities(ability, name);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        public IEnumerable<Abilities> GetAbilities()
        {
            return _repository.GetAbilities();
        }

        public Abilities GetAbilitiesByName(string name)
        {
            var ability = _repository.GetAbilitiesByName(name);
            if (ability == null)
            {
                throw new NotFoundException($"Ability with name {name} not found.");
            }
            return ability;
        }

        public void InsertAbilities(Abilities ability)
        {
            if (ability == null || ability.Name == null)
            {
                throw new BadRequestException("Ability require a name.");
            }
            if (_repository.AbilityExist(ability.Name))
            {
                throw new AlreadyExistException($"Ability with name {ability.Name} already exist.");
            }
            try
            {
                _repository.InsertAbilities(ability);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);

            }
        }
    }
}