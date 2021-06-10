// using System.Collections.Generic;
// using System.Reflection;
// using NUnit.Framework;
// using RoleplayGame;

// namespace Library.Test
// {
//     public class AttackEncounterTestV2
//     {

//          public void Setup()
//         {
//             this.legolas = new Archer("Legolas");
//             this.bow = new Bow();
//             legolas.AddItem(bow);
//             this.aragorn = new Knight("Aragorn");
//             this.sword = new Sword();
//             this.shield = new Shield();
//             this.armor = new Armor();
//             aragorn.AddItem(sword);
//             aragorn.AddItem(shield);
//             aragorn.AddItem(armor);
//         }


//         [Test]
//         public void TestEncounterHeroWhoKillsGetsVictoryPoints()
//         {
//             Enemy enemy = new EnemyStub(0, 0, 1);
//             Hero hero1 = new HeroStub(40, 0);
//             Hero hero2 = new HeroStub(40, 0);
//             Hero hero3 = new HeroStub(40, 0);
//             Hero hero4 = new HeroStub(40, 0);
//             AttackEncounter encounter = new AttackEncounter(
//                 new List<Hero> { hero1, hero2, hero3, hero4 },
//                 new List<Enemy> { enemy }
//             );

//             encounter.DoEncounter();

//             Assert.AreEqual(0, hero1.CollectedVPs);
//             Assert.AreEqual(0, hero2.CollectedVPs);
//             Assert.AreEqual(1, hero3.CollectedVPs);
//             Assert.AreEqual(0, hero4.CollectedVPs);
//         }
//     }
// }