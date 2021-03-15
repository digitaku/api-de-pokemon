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
        [HttpGet]
        public string GetAll()
        {
            return "pikachu";
        }

        [HttpGet("{nome}")]
        public string GetOne(string nome)
        {
            return $"toma ai teu {nome}";
        }
    }
}
