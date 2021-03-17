using api_de_pokemon.Dto;
using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
using api_de_pokemon.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public PokemonController(IPokemonServices services, IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPokemons()
        {
            try
            {
                return Ok(_mapper.Map<ICollection<PokemonDto>>(_services.GetPokemons()));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetPokemonByName(string name)
        {
            try
            {
                return Ok(_mapper.Map<PokemonDto>(_services.GetPokemonByName(name)));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        public IActionResult CreatePokemon([FromBody] PokemonDto pokemon)
        {
            try
            {
                _services.InsertPokemon(_mapper.Map<Pokemon>(pokemon));
                return Created("", pokemon);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{name}")]
        public IActionResult EditPokemon([FromBody] PokemonDto pokemon, string name)
        {
            try
            {
                _services.EditPokemon(_mapper.Map<Pokemon>(pokemon), name);
                return Ok(pokemon);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{name}")]
        public IActionResult DeletePokemon(string name)
        {
            try
            {
                _services.DeletePokemon(name);
                return NoContent();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
