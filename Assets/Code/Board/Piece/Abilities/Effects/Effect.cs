namespace Merge.Board.Abilities.Effects
{
    public class Effect
    {
        public static Effect None = new Effect();
    }

    public class NoneEffect : Effect { }

    public class SpawnPieceEffect : Effect
    {
        public string Id;
    }
}