using Entidades;
using PruebaTecnica.Repositorios;

namespace PruebaTecnica
{
    public class ProcesarPokemones
    {
        private readonly IPokemonRepositorio pokemonRepositorio;

        public ProcesarPokemones(IPokemonRepositorio pokemonRepositorio)
        {
            this.pokemonRepositorio = pokemonRepositorio;
        }
        public async Task<List<PokemonInfoModel>> Procesar(FilterPokemonViewModel? criteria)
        {
            var tipos = GetTypes(criteria?.Typo);
            List<PokemonInfoModel> ap = await GetPokemonsByTypeAsync(tipos);

            if (!string.IsNullOrEmpty(criteria?.Name))
            {
                return ap.Where(x => x.Name.Equals(criteria.Name.ToLower())).ToList();
            }

            return ap;
        }
        private async Task<List<PokemonInfoModel>> GetPokemonsByTypeAsync(List<string> tipos)
        {
            List<PokemonInfoModel> ap = new List<PokemonInfoModel>();

            foreach (var t in tipos)
            {
                try
                {
                    var ptRes = await this.pokemonRepositorio.GetPokemonByType(t);
                    foreach (var p in ptRes.Pokemon)
                    {
                        string pUrl = p.Pokemon.Url;
                        var pInfo = await this.pokemonRepositorio.GetPokemon(pUrl);
                        ap.Add(pInfo);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"¡Err al btr ls Pkmn dl tpo '{t}'!");
                }
            }

            return ap;
        }
        private List<string> GetTypes(string type)
        {
            List<string> types = new List<string>();

            if (!string.IsNullOrEmpty(type))
            {
                types.Add(type);
            }
            else
            {
                return new List<string> {
                "Fire", "Electric" };
            }
            return types;
        }
    }
}
