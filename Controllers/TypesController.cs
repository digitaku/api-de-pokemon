using api_de_pokemon.Entities;
using api_de_pokemon.Exceptions;
using api_de_pokemon.Services;
using api_de_pokemon.Services.Implementation;
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
        public TypesController(ITypesServices services)
        {
            this._services = services;
        }
        [HttpGet]
        public IActionResult GetTypes()
        {
            try
            {
                return Ok(_services.GetTypes());
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
                return Ok(_services.GetTypesByName(name));
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
        public IActionResult CreateType([FromBody] Types type)
        {
            try
            {
                _services.InsertTypes(type);
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
        public IActionResult EditType([FromBody] Types type, string name)
        {
            try
            {
                _services.EditTypes(type, name);
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