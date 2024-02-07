using Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly ProcesarPokemones procesarPokemones;

        public PokemonController(ProcesarPokemones procesarPokemones)
        {
            this.procesarPokemones = procesarPokemones;
        }
        [HttpGet]
        public async Task<IActionResult> GetPokemons()
        {
            var pokemones = await this.procesarPokemones.Procesar(null);
            return Ok(JsonConvert.SerializeObject(pokemones));
        }

        [HttpPost]
        public async Task<IActionResult> GetPokemonByCriteria([FromBody] FilterPokemonViewModel filter)
        {
            var pokemones = await this.procesarPokemones.Procesar(filter);
            return Ok(JsonConvert.SerializeObject(pokemones));
        }
    }
}
