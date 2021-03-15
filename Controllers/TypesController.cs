using api_de_pokemon.Entities;
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
        [HttpPost]
        public IActionResult CreateType([FromBody] Types type)
        {
            try
            {
                _services.InsertTypes(type);
                return Ok(type);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}