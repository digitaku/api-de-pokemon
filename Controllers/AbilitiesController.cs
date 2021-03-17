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
    public class AbilitiesController : ControllerBase
    {
        private readonly IAbilitiesServices _services;
        private readonly IMapper _mapper;
        public AbilitiesController(IAbilitiesServices services, IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }
        [HttpGet("{name}")]
        public IActionResult GetAbilitiesByName(string name)
        {
            try
            {
                return Ok(_mapper.Map<AbilitiesDto>(_services.GetAbilitiesByName(name)));
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
                return Ok(_mapper.Map<ICollection<AbilitiesDto>>(_services.GetAbilities()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateAbility([FromBody] AbilitiesDto ability)
        {
            try
            {
                _services.InsertAbilities(_mapper.Map<Abilities>(ability));
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
        public IActionResult EditAbility([FromBody] AbilitiesDto ability, string name)
        {
            try
            {
                _services.EditAbilities(_mapper.Map<Abilities>(ability), name);
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