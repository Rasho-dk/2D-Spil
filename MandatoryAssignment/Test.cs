//using System;
//using System.Collections.Generic;

//public class World
//{
//    public int MaxX { get; set; }
//    public int MaxY { get; set; }
//    public List<Creature> Creatures { get; set; } = new List<Creature>();
//    public List<WorldObject> WorldObjects { get; set; } = new List<WorldObject>();
//}

//public class Creature
//{
//    public string Name { get; set; }
//    public int HitPoint { get; set; }
//    public List<AttackItem> AttackItems { get; set; } = new List<AttackItem>();
//    public List<DefenceItem> DefenceItems { get; set; } = new List<DefenceItem>();

//    public int Hit()
//    {
//        // Implement logic for calculating hit points
//        return 0;
//    }

//    public void ReceiveHit(int hit)
//    {
//        // Implement logic for handling received hits
//    }

//    public void Loot(WorldObject worldObject)
//    {
//        // Implement logic for looting items from the world
//    }
//}

//public class WorldObject
//{
//    public string Name { get; set; }
//    public bool Lootable { get; set; }
//    public bool Removeable { get; set; }
//    public int X { get; set; } // X-coordinate in the world
//    public int Y { get; set; } // Y-coordinate in the world
//}

//public class AttackItem
//{
//    public string Name { get; set; }
//    public int Hit { get; set; }
//    public int Range { get; set; }
//    public bool FoundInChest { get; set; } // Can be found in treasure chests or bonus boxes
//}

//public class DefenceItem
//{
//    public string Name { get; set; }
//    public int ReduceHitPoint { get; set; }
//    public bool FoundInChest { get; set; } // Can be found in treasure chests or bonus boxes
//}

//// Example usage:
//class Program
//{
//    static void Main()
//    {
//        var world = new World { MaxX = 100, MaxY = 100 };

//        var dragon = new Creature { Name = "Dragon", HitPoint = 100 };
//        var sword = new AttackItem { Name = "Sword", Hit = 20, Range = 2, FoundInChest = true };
//        var shield = new DefenceItem { Name = "Shield", ReduceHitPoint = 10, FoundInChest = false };

//        dragon.AttackItems.Add(sword);
//        dragon.DefenceItems.Add(shield);

//        world.Creatures.Add(dragon);

//        var treasureChest = new WorldObject { Name = "Treasure Chest", Lootable = true, Removeable = true, X = 50, Y = 30 };
//        world.WorldObjects.Add(treasureChest);
//    }
//}
