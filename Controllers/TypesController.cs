using api_de_pokemon.Dto;
using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
using api_de_pokemon.Services;
using api_de_pokemon.Services.Implementation;
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
    public class TypesController : ControllerBase
    {
        private readonly ITypesServices _services;
        private readonly IMapper _mapper;
        public TypesController(ITypesServices services, IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTypes()
        {
            try
            {
                return Ok(_mapper.Map<ICollection<TypesDto>>(_services.GetTypes()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpGet("{name}")]
        public IActionResult GetTypeByName(string name)
        {
            try
            {
                return Ok(_mapper.Map<TypesDto>(_services.GetTypesByName(name)));
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
        [HttpPost]
        public IActionResult CreateType([FromBody] TypesDto type)
        {
            try
            {
                _services.InsertTypes(_mapper.Map<Types>(type));
                return Created("Success", type);
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
        public IActionResult EditType([FromBody] TypesDto type, string name)
        {
            try
            {
                _services.EditTypes(_mapper.Map<Types>(type), name);
                return Ok(type);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{name}")]
        public IActionResult DeleteType(string name)
        {
            try
            {
                _services.DeleteTypes(name);
                return NoContent();
            }
            catch (BusinessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}