using MandatoryAssignment;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Factories;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Weapons;

class Program
{
    static void Main(string[] args)
    {

        WeaponTest(new WeaponFactory(), new DefenceFactory());


    }

    public static void WeaponTest(IWeaponFactory weaponfactory, IDefenceFactory defenceFactory)
    {
        var world = new World { MaxX = 100, MaxY = 100 };


        IWeapon axe = weaponfactory.CreateWeapon(WeaponType.Axe);
        IWeapon sowrd = weaponfactory.CreateWeapon(WeaponType.Sword);
        IWeapon bow = weaponfactory.CreateWeapon(WeaponType.Bow);

        IDefence shield = defenceFactory.CreateDefence(DefenceType.Shield);
        IDefence helmet = defenceFactory.CreateDefence(DefenceType.Helmet);
        IDefence armor = defenceFactory.CreateDefence(DefenceType.Armor);

        ////conforming the the axe is an obj of type AttackItem not IWeapon

        world.WorldObjects.Add(new WorldObject("Treasure Chest", true, false, 50, 30, (AttackItemBase)axe, (DefenceItemBase)shield));
        world.WorldObjects.Add(new WorldObject("Bonus Box", true, false, 60, 40, (AttackItemBase)sowrd, (DefenceItemBase)helmet));
        world.WorldObjects.Add(new WorldObject("Bonus Box", true, false, 60, 40, (AttackItemBase)bow, (DefenceItemBase)armor));


        var dragon = new Creature(1, "Dragon", 100);
        var goblin = new Creature(2, "Goblin", 50);
        var human = new Creature(3, "Human", 50);

        world.Creatures.Add(dragon);
        world.Creatures.Add(goblin);
        world.Creatures.Add(human);

        dragon.Loot(world.WorldObjects[0]);
        goblin.Loot(world.WorldObjects[1]);
        human.Loot(world.WorldObjects[2]);










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
