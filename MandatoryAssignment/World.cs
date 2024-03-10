namespace MandatoryAssignment
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        private List<CreatureBase> creatures;
        private List<WorldObject> worldObjects;
        public CreatureBase Creature { get; set; }
        public WorldObject WorldObject { get; set; }


        public World()
        {
            creatures = new List<CreatureBase>();
            worldObjects = new List<WorldObject>();
        }

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            creatures = new List<CreatureBase>();
            worldObjects = new List<WorldObject>();

        }

        public void AddCreature(CreatureBase creature)
        {
            creatures.Add(creature);
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            worldObjects.Add(worldObject);
        }

        public List<WorldObject> WorldObjectsList()
        {
            return worldObjects;
        }
        public IEnumerable<CreatureBase> CreaturesList() { return creatures; }

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }

}
