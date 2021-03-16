using System;
using System.Collections.Generic;
using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
using api_de_pokemon.Repositories;

namespace api_de_pokemon.Services.Implementation
{
    public class PokemonServices : IPokemonServices
    {

        private readonly IPokemonRepository _repository;
        public PokemonServices(IPokemonRepository repository)
        {
            this._repository = repository;
        }

        public Pokemon GetPokemonByName(string name)
        {
            var pokemon = _repository.GetPokemonByName(name);
            if (pokemon == null)
            {
                throw new NotFoundException($"Pokemon with name {name} not found.");
            }
            return pokemon;
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            return _repository.GetPokemons();
        }

        public IEnumerable<Pokemon> GetPokemonsByAbilities(string name)
        {
            var pokemon = _repository.GetPokemonsByAbilities(name);
            if (pokemon == null)
            {
                throw new NotFoundException($"Pokemon with name {name} not found.");
            }
            return pokemon;
        }

        public IEnumerable<Pokemon> GetPokemonsByTypes(string name)
        {
            var pokemon = _repository.GetPokemonsByTypes(name);
            if (pokemon == null)
            {
                throw new NotFoundException($"Pokemon with name {name} not found.");
            }
            return pokemon;
        }

        public void DeletePokemon(string name)
        {
            if (name == null)
            {
                throw new BadRequestException($"Pokemon require a name.");
            }
            if (!_repository.PokemonExist(name))
            {
                throw new NotFoundException($"Pokemon with name {name} not found.");
            }
            try
            {
                _repository.DeletePokemon(_repository.GetPokemonByName(name));
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        public void EditPokemon(Pokemon pokemon, string name)
        {
            if (pokemon == null || pokemon.Name == null || pokemon.Alias == null || pokemon.ImageUrl == null || name == null)
            {
                throw new BadRequestException($"Pokemon require a name, alias and imageUrl.");
            }
            if (!_repository.PokemonExist(name))
            {
                throw new NotFoundException($"Pokemon with name {pokemon.Name} not found.");
            }
            try
            {
                _repository.EditPokemon(pokemon, name);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        public void InsertPokemon(Pokemon pokemon)
        {
            if (pokemon == null || pokemon.Name == null || pokemon.Alias == null || pokemon.ImageUrl == null)
            {
                throw new BadRequestException($"Pokemon require a name, alias and imageUrl.");
            }
            if (_repository.PokemonExist(pokemon.Name))
            {
                throw new AlreadyExistException($"Pokemon with name {pokemon.Name} already exist.");
            }
            try
            {
                _repository.InsertPokemon(pokemon);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}