using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
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
    public class AbilitiesController : ControllerBase
    {
        private readonly IAbilitiesServices _services;
        public AbilitiesController(IAbilitiesServices services)
        {
            this._services = services;
        }
        [HttpGet("{name}")]
        public IActionResult GetAbilitiesByName(string name)
        {
            try
            {
                return Ok(_services.GetAbilitiesByName(name));
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
        [HttpGet]
        public IActionResult GetAbilities()
        {
            try
            {
                return Ok(_services.GetAbilities());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateAbility([FromBody] Abilities ability)
        {
            try
            {
                _services.InsertAbilities(ability);
                return Created("", ability);
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
        public IActionResult EditAbility([FromBody] Abilities ability, string name)
        {
            try
            {
                _services.EditAbilities(ability, name);
                return Ok(ability);
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
        public IActionResult DeleteAbility(string name)
        {
            try
            {
                _services.DeleteAbilities(name);
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