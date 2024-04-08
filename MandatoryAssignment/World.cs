using MandatoryAssignment.Creature.Template;
using MandatoryAssignment.Gamelogger;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Models;
using MandatoryAssignment.Observer;
using System.Diagnostics;

namespace MandatoryAssignment
{
    public abstract class World : IObserver
    {
        #region Properties
        public string Id { get; private set; }

        //public int MaxX { get; set; }
        //public int MaxY { get; set; }

        /// <summary>
        /// Represents the position of the world
        /// </summary>
        //public Position Position { get; set; }
        public IPosition Position { get; set; }
        /// <summary>
        /// Represents the name of the world
        /// </summary>
        public string WorldName { get; set; }

        /// <summary>
        /// Represents a list of creatures in the world
        /// </summary>
        private List<CreatureBase> creatures;
        /// <summary>
        /// Represents a list of world objects in the world
        /// </summary>
        private List<WorldObject> worldObjects;

        //public CreatureBase Creature { get; set; }
        //public WorldObject WorldObject { get; set; }

        #endregion Properties


        /// <summary>
        /// This is the constructor for the World class that use position takes in the  x and y coordinates of the world and the world name
        /// This constructor also initializes the creatures and worldObjects list to empty lists allow for adding creatures and world objects to the world
        /// </summary>
        protected World()
        {
            //MaxX = maxX;
            //MaxY = maxY;
            Id = Guid.NewGuid().ToString().Substring(0, 8); ;
            Position = new Position();
            creatures = new List<CreatureBase>();
            worldObjects = new List<WorldObject>();

            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "World created: " + this.ToString());

        }

        /// <summary>
        /// This is the constructor for the World class that takes in the position of the world, the world name, a list of creatures and a list of world objects
        /// </summary>
        /// <param name="position">Position of the world</param> 
        /// <param name="worldName">Name of the world</param>
        /// <param name="creatures">List of creatures</param>
        /// <param name="worldObjects">List of world objects</param>
        protected World(IPosition position, string worldName)
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8); ;
            Position = position;
            WorldName = worldName;
            creatures = new List<CreatureBase>();
            worldObjects = new List<WorldObject>();

            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "World created: " + this.ToString());
        }


        /// <summary>
        /// This method adds a creature to the world
        /// </summary>
        /// <param name="creature">The creature to be added to the world</param>
        public void AddCreature(CreatureBase creature)
        {
            creatures.Add(creature);
            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "Creature added to world: " + creature.ToString());

            creature.Attach(this);
        }
        /// <summary>
        /// This method adds a world object to the world
        /// </summary>
        /// <param name="worldObject">The world object to be added to the world</param>
        public void AddWorldObject(WorldObject worldObject)
        {
            worldObjects.Add(worldObject);
            TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "WorldObject added to world: " + worldObject);
        }

        /// <summary>
        /// This method returns a list of all the creatures in the world
        /// </summary>
        /// <returns>List of creatures in the world</returns>
        public List<WorldObject> WorldObjectsList()
        {
            return worldObjects;
        }
        /// <summary>
        /// This method returns a list of all the world objects in the world
        /// </summary>
        /// <returns>List of world objects in the world</returns>
        public IEnumerable<CreatureBase> CreaturesList() { return creatures; }

        /// <summary>
        /// This method returns a string representation of the world
        /// </summary>
        /// <returns>Returns a string representation of the world</returns>
        public override string ToString()
        {
            string creaturesString = string.Join(", ", creatures);
            string worldObjectsString = string.Join(", ", worldObjects);

            //return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}, {nameof(WorldName)}={WorldName}," +
            //    $" Creatures={creaturesString}, WorldObjects={worldObjectsString}}}";

            return $"{{{nameof(Id)}={Id.ToString()} ,{nameof(Position.X)}={Position.X.ToString()}, {nameof(Position.Y)}={Position.Y.ToString()}, {nameof(WorldName)}={WorldName}," +
                $" Creatures={creaturesString}, WorldObjects={worldObjectsString}}}";


        }
        /// <summary>
        /// This method is used to update the creature list when a creature is dead
        /// </summary>
        /// <param name="sender">The creature that is dead</param> 
        /// <param name="e">The event arguments</param>
        public void Update(object sender, ChangeEventArgs e)
        {
            if (sender is CreatureBase)
            {
                CreatureBase creature = (CreatureBase)sender;
                if (creature.IsDead())
                {
                    creatures.Remove(creature);
                    // Detach the creature from the observer
                    //using reflection to call the Detach method
                    sender.GetType().GetMethod("Detach")?.Invoke(creature, new object[] { (IObserver)this });
                    TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "Creature removed from world: " + creature.ToString());
                }
            }
        }
      

    }

}
