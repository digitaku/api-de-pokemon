using System;
using System.Collections.Generic;
using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
using api_de_pokemon.Repositories;

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
            Abilities abilityExist = _repository.GetAbilitiesByName(name);
            if (abilityExist == null)
            {
                throw new NotFoundException($"Ability with name {name} not found.");
            }
            try
            {
                _repository.DeleteAbilities(abilityExist);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);
            }
        }

        public void EditAbilities(Abilities ability)
        {
            if (ability == null || ability.Name == null)
            {
                throw new BadRequestException("Ability require a name.");
            }
            Abilities abilityExist = _repository.GetAbilitiesByName(ability.Name);
            if (ability == null)
            {
                throw new NotFoundException($"Ability with name {ability.Name} not found.");

            }
            try
            {
                abilityExist.Name = ability.Name;
                abilityExist.EffectDescription = ability.EffectDescription;
                abilityExist.IsHidden = ability.IsHidden;
                _repository.DeleteAbilities(abilityExist);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                throw new BusinessException(ex.Message);

            }
        }

        public IEnumerable<Abilities> GetAbilities()
        {
            return _repository.GetAbilities();
        }

        public Abilities GetAbilitiesByName(string name)
        {
            return _repository.GetAbilitiesByName(name);
        }

        public void InsertAbilities(Abilities ability)
        {
            if (ability == null || ability.Name == null)
            {
                throw new BadRequestException("Ability require a name.");
            }
            Abilities typeExist = _repository.GetAbilitiesByName(ability.Name);
            if (typeExist != null)
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