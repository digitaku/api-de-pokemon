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
            return _repository.GetPokemonByName(name);
        }

        public IEnumerable<Pokemon> GetPokemons()
        {
            return _repository.GetPokemons();
        }

        public IEnumerable<Pokemon> GetPokemonsByAbilities(string name)
        {
            return _repository.GetPokemonsByAbilities(name);
        }

        public IEnumerable<Pokemon> GetPokemonsByTypes(string name)
        {
            return _repository.GetPokemonsByTypes(name);
        }

        public void DeletePokemon(string name)
        {
            if (name == null)
            {
                throw new BadRequestException($"Pokemon require a name.");
            }
            Pokemon pokemonExist = _repository.GetPokemonByName(name);
            if (pokemonExist == null)
            {
                throw new NotFoundException($"Pokemon with name {name} not found.");
            }
            try
            {
                _repository.DeletePokemon(pokemonExist);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        public void EditPokemon(Pokemon pokemon)
        {
            if (pokemon == null || pokemon.Name == null || pokemon.Alias == null || pokemon.ImageUrl == null)
            {
                throw new BadRequestException($"Pokemon require a name, alias and imageUrl.");
            }
            Pokemon pokemonExist = _repository.GetPokemonByName(pokemon.Name);
            if (pokemonExist == null)
            {
                throw new NotFoundException($"Pokemon with name {pokemon.Name} not found.");
            }
            try
            {
                pokemonExist.Name = pokemon.Name;
                pokemonExist.Alias = pokemon.Alias;
                pokemonExist.Description = pokemon.Description;
                pokemonExist.ImageUrl = pokemon.ImageUrl;
                pokemonExist.Color = pokemon.Color;
                pokemonExist.Height = pokemon.Height;
                pokemonExist.Weight = pokemon.Weight;
                _repository.EditPokemon(pokemonExist);
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
            Pokemon pokemonExist = _repository.GetPokemonByName(pokemon.Name);
            if (pokemonExist != null)
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