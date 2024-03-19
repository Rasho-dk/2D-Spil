using MandatoryAssignment;
using MandatoryAssignment.Configuration;
using MandatoryAssignment.Creature;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Factories;
using MandatoryAssignment.Gamelogger;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Types;
using MandatoryAssignment.Weapons;
using SpilApp;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        

        WeaponTest(new WeaponFactory(), new DefenceFactory()); 

    }

    public static void WeaponTest(IWeaponFactory weaponfactory, IDefenceFactory defenceFactory)
    {
        try
        {
            var test = GameConfiguration.GetConfiguration();
            test.LogXML = true;
            test.LogConsole = true;
            var world = new World();
            world.MaxX = test.MaxX;
            world.MaxY = test.MaxY;
            world.WorldName = test.WorldName;



            IWeapon axe = weaponfactory.Create(WeaponType.Axe);
            IWeapon sowrd = weaponfactory.Create(WeaponType.Sword);
            IWeapon bow = weaponfactory.Create(WeaponType.Bow);

            IWeapon createWeapon = weaponfactory.Create("test", 10, 10);


            IDefence shield = defenceFactory.Create(DefenceType.Shield);
            IDefence helmet = defenceFactory.Create(DefenceType.Helmet);
            IDefence armor = defenceFactory.Create(DefenceType.Armor);

            ////conforming the the axe is an obj of type AttackItem not IWeapon
            world.AddWorldObject(new WorldObject("Treasure Chest", true, false, 50, 30, (AttackItemBase)axe, (DefenceItemBase)shield));
            world.AddWorldObject(new WorldObject("Bonus Box", true, false, 50, 30, (AttackItemBase)sowrd, (DefenceItemBase)helmet));
            world.AddWorldObject(new WorldObject("Bonus Box", true, false, 60, 40, (AttackItemBase)bow, (DefenceItemBase)armor));


            var dragon = new Dragon(1, "Dragon", 100);
            var goblin = new CreateCreature(2, "Goblin", 50);


            var human = new Creature(3, "Human", 100);



            world.AddCreature(dragon);
            world.AddCreature(goblin);
            world.AddCreature(human);

            //world.AddCreature(human);

            dragon.Loot(world.WorldObjectsList()[0]);
            goblin.Loot(world.WorldObjectsList()[1]);
            human.Loot(world.WorldObjectsList()[2]);


            for (int i = 0; i < 5; i++)
            {
                dragon.Fight(goblin);
                if (goblin.IsDead())
                {
                    break;
                }
            }

        }
        catch (FileNotFoundException ex)
        {
            TraceSourceLibrary.LogEvent(TraceEventType.Error, 1, "Error in Confiqration file path: " + ex.Message);
        }

        //goblin.Fight(human);
        //human.Fight(dragon);




        //TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "World created: " + world.ToString());



        //print world objects

        //Console.WriteLine(world);


        //// Print all information to the console
        //Console.WriteLine("World Objects:");
        //foreach (var worldObject in world.WorldObjectsList())
        //{
        //    Console.WriteLine($"Name: {worldObject.Name}, Lootable: {worldObject.Lootable}, X: {worldObject.X}, Y: {worldObject.Y}");
        //    Console.WriteLine($"Attack Item: {worldObject.AttackItem.Name}, Defence Item: {worldObject.DefenceItem.Name}");
        //    Console.WriteLine();
        //}

        //Console.WriteLine("\nCreatures:");


        //foreach (Creature creature in world.CreaturesList().ToList())
        //{
        //    Console.WriteLine(creature);

        //}

    }
    
}
