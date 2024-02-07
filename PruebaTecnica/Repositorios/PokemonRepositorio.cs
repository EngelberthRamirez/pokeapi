using Entidades;
using Newtonsoft.Json;

namespace PruebaTecnica.Repositorios
{
    public class PokemonRepositorio : IPokemonRepositorio
    {
        private readonly HttpClient client;

        public PokemonRepositorio(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }
        public async Task<PokemonInfoModel> GetPokemon(string urlRecurso)
        {
            string url = urlRecurso;
            HttpResponseMessage rsp = await this.client.GetAsync(url);
            rsp.EnsureSuccessStatusCode();
            string aRsp = rsp.Content.ReadAsStringAsync().Result;
            var ptRes = JsonConvert.DeserializeObject<PokemonInfoModel>(aRsp);
            return ptRes;
        }

        public async Task<PokemonTypeResultModel> GetPokemonByType(string type)
        {
            string url = $"type/{type.ToLower()}/";
            HttpResponseMessage rsp = await this.client.GetAsync(url);
            rsp.EnsureSuccessStatusCode();
            string aRsp = rsp.Content.ReadAsStringAsync().Result;
            var ptRes = JsonConvert.DeserializeObject<PokemonTypeResultModel>(aRsp);
            return ptRes;
        }
    }
}
