using MandatoryAssignment;
using MandatoryAssignment.Configuration;
using MandatoryAssignment.Creature;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Factories;
using MandatoryAssignment.Gamelogger;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Interfaces.Generic;
using MandatoryAssignment.Interfaces.Types;
using MandatoryAssignment.Weapons;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        WeaponTest(new WeaponFactory(), new DefenceFactory()); 

    }

    public static void WeaponTest(IWeaponFactory weaponfactory, IDefenceFactory defenceFactory)
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

        //IWeapon createWeapon = weaponfactory.Create(WeaponType.CreateWeapon);



        IDefence shield = defenceFactory.Create(DefenceType.Shield);
        IDefence helmet = defenceFactory.Create(DefenceType.Helmet);
        IDefence armor = defenceFactory.Create(DefenceType.Armor);



        ////conforming the the axe is an obj of type AttackItem not IWeapon

        world.AddWorldObject(new WorldObject("Treasure Chest", true, false, 50, 30, (AttackItemBase)axe, (DefenceItemBase)shield));
        world.AddWorldObject(new WorldObject("Bonus Box", true, false, 50, 30, (AttackItemBase)sowrd, (DefenceItemBase)helmet));
        world.AddWorldObject(new WorldObject("Bonus Box", true, false, 60, 40, (AttackItemBase)bow, (DefenceItemBase)armor));


        var dragon = new Dragon(1, "Dragon", 100);
        var goblin = new CreateCreature(2, "Goblin", 50);



        world.AddCreature(dragon);
        world.AddCreature(goblin);

        //world.AddCreature(human);

        dragon.Loot(world.WorldObjectsList()[0]);
        goblin.Loot(world.WorldObjectsList()[1]);

        //human.Loot(world.WorldObjectsList()[2]);

        dragon.Fight(goblin);

        Console.WriteLine(dragon.ToString());
        Console.WriteLine(goblin.ToString());


        TraceSourceLibrary.LogEvent(TraceEventType.Information, 1, "World created: " + world.ToString());



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

    //private static void WorldTest()
    //{
    //    var world = new World { MaxX = 100, MaxY = 100 };

    //    var dragon = new Creature("Dragon", 100);
    //    var goblin = new Creature("Goblin", 50);

    //    var sword = new AttackItem { Name = "Sword", Hit = 20, Range = 2, FoundInChest = true };
    //    var shield = new DefenceItem { Name = "Shield", ReduceHitPoint = 10, FoundInChest = false };

    //    var axe = new AttackItem { Name = "Axe", Hit = 30, Range = 3, FoundInChest = true };
    //    var helmet = new DefenceItem { Name = "Helmet", ReduceHitPoint = 20, FoundInChest = false };

    //    world.WorldObjects.Add(new WorldObject("Treasure Chest", true, true, 50, 30, sword, shield));
    //    world.WorldObjects.Add(new WorldObject("Bonus Box", true, true, 60, 40, axe, helmet));

    //    world.WorldObjects.ForEach(
    //        worldObject =>
    //        {
    //            if (worldObject.Lootable)
    //            {
    //                dragon.Loot(worldObject);
    //                goblin.Loot(worldObject);
    //            }
    //        }
    //            );

    //    dragon.AttackItems.Add(sword);
    //    dragon.DefenceItems.Add(shield);

    //    goblin.AttackItems.Add(axe);
    //    goblin.DefenceItems.Add(helmet);

    //    world.Creatures.Add(dragon);
    //    world.Creatures.Add(goblin);

    //    var treasureChest = new WorldObject(
    //        "Treasure Chest", true, true, 50, 30, sword, shield
    //    );

    //    world.WorldObjects.Add(treasureChest);

    //    foreach (var creature in world.Creatures)
    //    {
    //        Console.WriteLine(creature.Name + " " + creature.HitPoint);

    //        foreach (var attackItem in creature.AttackItems)
    //        {
    //            Console.WriteLine(attackItem.Name + " " + attackItem.Hit + " " + attackItem.Range + " " + attackItem.FoundInChest);
    //            creature.Hit(); // Brug Hit() metoden på creaturen med angrebsvåbnet
    //            Console.WriteLine("hitpoint" + creature.Hit());
    //        }

    //        foreach (var defenceItem in creature.DefenceItems)
    //        {
    //            Console.WriteLine(defenceItem.Name + " " + defenceItem.ReduceHitPoint + " " + defenceItem.FoundInChest);
    //            creature.ReceiveHit(defenceItem.ReduceHitPoint); // Brug ReceiveHit() metoden på creaturen med forsvarsvåbnet
    //        }
    //    }

    //    foreach (var worldObject in world.WorldObjects)
    //    {
    //        Console.WriteLine(worldObject.AttackItem.Name + " " + worldObject.AttackItem.Hit + " " + worldObject.AttackItem.Range + " " + worldObject.AttackItem.FoundInChest);
    //        Console.WriteLine(worldObject.DefenceItem.Name + " " + worldObject.DefenceItem.ReduceHitPoint + " " + worldObject.DefenceItem.FoundInChest);
    //    }

    //    Console.ReadLine();
    //}
}
