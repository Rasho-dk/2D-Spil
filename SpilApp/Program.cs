using MandatoryAssignment.Configuration;
using MandatoryAssignment.Creature;
using MandatoryAssignment.Defenses;
using MandatoryAssignment.Enumtype;
using MandatoryAssignment.Factories;
using MandatoryAssignment.Gamelogger;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Weapons;
using SpilApp;
using System.ComponentModel;
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

            var world = new MyWorld();
            world.Position.X = test.Position.X;
            world.Position.X = test.Position.Y;
            world.WorldName = test.WorldName;



            IWeapon axe = weaponfactory.Create(WeaponType.Axe);
            IWeapon sowrd = weaponfactory.Create(WeaponType.Sword);
            IWeapon bow = weaponfactory.Create(WeaponType.Bow);

            IWeapon createWeapon = weaponfactory.Create("test", 10, 10);


            IDefence shield = defenceFactory.Create(DefenceType.Shield);
            IDefence helmet = defenceFactory.Create(DefenceType.Helmet);
            IDefence armor = defenceFactory.Create(DefenceType.Armor);

            ////conforming the the axe is an obj of type AttackItem not IWeapon
            world.AddWorldObject(new MyWorldObj("Treasure Chest", true, false, new Position(50, 20), (AttackItemBase)axe, (DefenceItemBase)shield));
            world.AddWorldObject(new MyWorldObj("Bonus Box", true, false, new Position(50, 20), (AttackItemBase)sowrd, (DefenceItemBase)helmet));
            world.AddWorldObject(new MyWorldObj("Bonus Box", true, false, new Position(60, 20), (AttackItemBase)bow, (DefenceItemBase)armor));


            var dragon = new Dragon("Dragon", 100);
            var goblin = new CreateCreature("Goblin", 100);



            var human = new Creature("Human", 100);



            world.AddCreature(dragon);



            world.AddCreature(goblin);
            world.AddCreature(human);

            dragon.Loot(world.WorldObjectsList()[0]);
            goblin.Loot(world.WorldObjectsList()[1]);
            human.Loot(world.WorldObjectsList()[2]);


            //dragon.ReceiveReduceHitPoint(goblin.Hit());

            for (int i = 0; i < 5; i++)
            {
                dragon.Fight(goblin);

                if (goblin.IsDead())
                {
                    break;
                }
            }

        }
        catch (Exception ex)
        {
            TraceSourceLibrary.LogEvent(TraceEventType.Error, 1, "Error" + ex.Message);
        }


    }
 

}
