using Entidades;

namespace Servicios.Repositorios
{
    public interface IPokemonRepositorio
    {
        public Task<PokemonTypeResultModel> GetPokemonByType(string type);
        public Task<PokemonInfoModel> GetPokemon(string urlRecurso);
    }
}
