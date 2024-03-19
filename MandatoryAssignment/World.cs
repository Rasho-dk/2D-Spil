using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Gamelogger;
using System.Diagnostics;

namespace MandatoryAssignment
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string WorldName { get; set; }
        private List<CreatureBase> creatures;
        private List<WorldObject> worldObjects;
        public CreatureBase Creature { get; set; }
        public WorldObject WorldObject { get; set; }
        //public TraceEventType EventType { get; set; }

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
            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "Creature added to world: " + creature.ToString());
            
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            worldObjects.Add(worldObject);
            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "WorldObject added to world: " + worldObject);


        }

        public List<WorldObject> WorldObjectsList()
        {
            return worldObjects;
        }
        public IEnumerable<CreatureBase> CreaturesList() { return creatures; }

        public override string ToString()
        {
            string creaturesString = string.Join(", ", creatures);
            string worldObjectsString = string.Join(", ", worldObjects);

            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}, {nameof(WorldName)}={WorldName}," +
                $" Creatures={creaturesString}, WorldObjects={worldObjectsString}}}";


            //return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}, {nameof(WorldName)}={WorldName}, {nameof(Creature)}={Creature}, {nameof(WorldObject)}={WorldObject}}}";
        }
    }

}
