using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class EncounterTests
    {
        private Dwarf gimli;
        private IAttackItem axe;
        private Archer legolas;
        private IAttackItem bow;
        private EnemyDwarf badGimli;
        private EnemyArcher badLegolas;


        [SetUp]
        public void Setup()
        {
            this.legolas = new Archer("Legolas");
            this.gimli = new Dwarf("Gimli");

            this.bow = new Bow();
            this.axe = new Axe();

            this.badLegolas = new EnemyArcher("BadLegolas");
            this.badGimli = new EnemyDwarf("BadGimli");
        }

        [Test]
        public void TestStrongHeroKillsEnemiesAndGetsCuredWithFiveVPs()
        {
            legolas.AddItem(bow);
            legolas.AddItem(bow);

            badLegolas.AddItem(bow);

            BattleEncounter encounter = new BattleEncounter
            (new List<AbstractHero> { legolas }, new List<AbstractEnemy> { badLegolas });

            encounter.DoEncounter();

            Assert.AreEqual(encounter.EnemiesAlive().Count, 0);
            Assert.AreEqual(encounter.HeroesAlive().Count, 1);
            Assert.AreEqual(100, legolas.Health);
        }

        [Test]
        public void TestStrongEnemyKillsHeroAndDoesntReciveDamage()
        {
            legolas.AddItem(bow);

            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);

            BattleEncounter encounter = new BattleEncounter
            (new List<AbstractHero> { legolas }, new List<AbstractEnemy> { badLegolas });

            encounter.DoEncounter();

            Assert.AreEqual(encounter.EnemiesAlive().Count, 1);
            Assert.AreEqual(encounter.HeroesAlive().Count, 0);
            Assert.AreEqual(badLegolas.Health, 100);
        }

        [Test]
        public void TestStrongEnemyKillsHeroesButRecivesDamageFromSecondHero()
        {
            gimli.AddItem(axe);
            legolas.AddItem(bow);

            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);
            badLegolas.AddItem(bow);

            BattleEncounter encounter = new BattleEncounter
            (new List<AbstractHero> { legolas, gimli }, new List<AbstractEnemy> { badLegolas });

            encounter.DoEncounter();

            Assert.AreEqual(encounter.EnemiesAlive().Count, 1);
            Assert.AreEqual(encounter.HeroesAlive().Count, 0);
            Assert.AreNotEqual(badLegolas.Health, 100);
        }

        [Test]
        public void TestThreeHeroesWinOverOneEnemyButFristTwoHeroesDies()
        {
            Archer greenArrow = new Archer("GreenArrow");

            gimli.AddItem(axe);
            legolas.AddItem(bow);
            greenArrow.AddItem(bow);
            gimli.AddItem(axe);
            legolas.AddItem(bow);
            greenArrow.AddItem(bow);

            badGimli.AddItem(axe);
            badGimli.AddItem(axe);
            badGimli.AddItem(axe);
            badGimli.AddItem(axe);


            BattleEncounter encounter = new BattleEncounter(
                new List<AbstractHero> { legolas, gimli, greenArrow },
                new List<AbstractEnemy> { badGimli }
            );

            encounter.DoEncounter();

            Assert.AreEqual(encounter.HeroesAlive().Count, 1);
            Assert.AreEqual(encounter.EnemiesAlive().Count, 0);
            Assert.AreEqual(0, legolas.Health);
            Assert.AreEqual(0, gimli.Health);
            Assert.AreEqual(100, greenArrow.Health);
        }

        [Test]
        public void TestEncounterWhereHeroWinsLessThanFiveVPSDoesNotGetCured()
        {
            gimli.AddItem(axe);
            gimli.AddItem(axe);

            badGimli.AddItem(axe);

            BattleEncounter encounter = new BattleEncounter(
                new List<AbstractHero> { gimli },
                new List<AbstractEnemy> { badGimli }
            );

            encounter.DoEncounter();

            Assert.AreEqual(50, gimli.Health);
        }

        [Test]
        public void TestHeroThatGetsTheKillGetsTheVPs()
        {

            Archer greenArrow = new Archer("GreenArrow");

            gimli.AddItem(axe);
            legolas.AddItem(bow);
            greenArrow.AddItem(bow);
            gimli.AddItem(axe);
            legolas.AddItem(bow);
            greenArrow.AddItem(bow);

            badGimli.AddItem(axe);
            badGimli.AddItem(axe);
            badGimli.AddItem(axe);
            badGimli.AddItem(axe);


            BattleEncounter encounter = new BattleEncounter(
                new List<AbstractHero> { legolas, gimli, greenArrow },
                new List<AbstractEnemy> { badGimli }
            );

            encounter.DoEncounter();

            Assert.AreEqual(0, legolas.VPsAcumulated);
            Assert.AreEqual(0, gimli.VPsAcumulated);
            Assert.AreEqual(4, greenArrow.VPsAcumulated);
        }
    }
}
