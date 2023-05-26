using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Interfaces;
using PokemonReview.Models.Models;
using System.Reflection.Metadata.Ecma335;

namespace PokemonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {

        private readonly IPokemon _pokemon;

        public PokemonController(IPokemon PokemonRepository)
        {
            _pokemon = PokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type =typeof(IEnumerable<Pokemon>))]

        public IActionResult GetPokemons()
        {
            var pokemon = _pokemon.GetPokemons();

            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
         
    }
}
