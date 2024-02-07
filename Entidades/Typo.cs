namespace Entidades
{
    public enum Typo
    {
        Fuego = 0,
        Electrico = 1,
        Agua = 2,
        Planta = 3
    }

    public class FilterPokemonViewModel
    {
        public string Name { get; set; }
        public string Typo { get; set; }
    }
}
