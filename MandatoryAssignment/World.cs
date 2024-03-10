namespace MandatoryAssignment
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Creature> Creatures { get; set; } = new List<Creature>();
        public List<WorldObject> WorldObjects { get; set; } = new List<WorldObject>();
        public Creature Creature { get; set; }
        public WorldObject WorldObject { get; set; }




    }
}
