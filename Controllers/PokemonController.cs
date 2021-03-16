using api_de_pokemon.Entities;
using api_de_pokemon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_de_pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonServices _services;
        public PokemonController(IPokemonServices services)
        {
            this._services = services;
        }
        [HttpGet]
        public string GetPokemons()
        {
            return "pikachu";
        }

        [HttpGet("{nome}")]
        public string GetPokemonByName(string nome)
        {
            return $"toma ai teu {nome}";
        }
        public void CreatePokemon([FromBody] Pokemon pokemon) { }
        [HttpPut("{name}")]
        public void EditPokemon([FromBody] Pokemon pokemon) { }
        [HttpDelete("{name}")]
        public void DeletePokemon(string name) { }
    }
}
