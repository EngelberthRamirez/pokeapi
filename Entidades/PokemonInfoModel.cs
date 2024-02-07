namespace Entidades
{
    public class PokemonInfoModel
    {
        public string Name;
        public int Height;
        public int Weight;

        //Completar estos datos.
        public int Attack;
        public int HP;
        public int Defense;
        public int Speed;

        public List<PokemonStats> Stats { get; set; }
    }
}
