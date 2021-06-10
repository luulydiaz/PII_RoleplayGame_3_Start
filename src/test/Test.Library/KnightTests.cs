using NUnit.Framework;
using RoleplayGame;


namespace Test.Library
{
    public class KnightTests
    {
        private Knight aragorn;
        private Sword sword;
        private Shield shield;
        private Armor armor;
        private Archer legolas;
        private Bow bow;

        [SetUp]
        public void Setup()
        {
            this.legolas = new Archer("Legolas");
            this.bow = new Bow();
            legolas.AddItem(bow);
            this.aragorn = new Knight("Aragorn");
            this.sword = new Sword();
            this.shield = new Shield();
            this.armor = new Armor();
            aragorn.AddItem(sword);
            aragorn.AddItem(shield);
            aragorn.AddItem(armor);
        }

        [Test]
        public void Health_Is_Modified_By_Attack()      //Prueba que el metodo ReceiveAttack modifica la vida
        {
            int initialLife = aragorn.Health;
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            aragorn.ReceiveAttack(legolas.AttackValue);

            Assert.AreNotEqual(initialLife, aragorn.Health);
        }

        [Test]
        public void Health_Doesnt_Drop_Below_Zero()     //Prueba que la vida no puede bajar de cero
        {
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            aragorn.ReceiveAttack(legolas.AttackValue);

            Assert.AreEqual(aragorn.Health, 0);
        }

        [Test]
        public void Attack_Doesnt_Heal()                //Prueba que el metodo ReceiveAttack no cura si el ataque es menor a la defensa 
        {
            int initialLife = aragorn.Health;
            aragorn.ReceiveAttack(legolas.AttackValue);

            Assert.AreEqual(initialLife, aragorn.Health);
        }

        [Test]
        public void Healyh_Is_Modified_By_Cure()        //Prueba que el metodo Cure modifica la vida
        {
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            aragorn.ReceiveAttack(legolas.AttackValue);
            int actualLife = aragorn.Health;
            aragorn.Cure();

            Assert.AreNotEqual(actualLife, aragorn.Health);
        }

        [Test]
        public void Aragorn_Damage()                    //Prueba que la suma del daño del personaje es correcto
        {
            Assert.AreEqual(aragorn.AttackValue, sword.AttackValue);
        }

        [Test]
        public void Aragorn_Defense()                   //Prueba que la suma de la defensa del personaje es correcta
        {
            int defense = armor.DefenseValue + shield.DefenseValue;
            Assert.AreEqual(aragorn.DefenseValue, defense);
        }
    }
}
