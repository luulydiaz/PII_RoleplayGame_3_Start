using NUnit.Framework;
using RoleplayGame;


namespace Test.Library
{
    public class DwarfTests
    {
        private Dwarf gimli;
        private Axe axe;
        private Helmet helmet;
        private Shield shield;
        private Archer legolas;
        private Bow bow;

        [SetUp]
        public void Setup()
        {
            this.legolas = new Archer("Legolas");
            this.bow = new Bow();
            legolas.AddItem(bow);
            this.gimli = new Dwarf("Gimli");
            this.axe = new Axe();
            this.helmet = new Helmet();
            this.shield = new Shield();
            gimli.AddItem(axe);
            gimli.AddItem(helmet);
            gimli.AddItem(shield);
        }

        [Test]
        public void Health_Is_Modified_By_Attack()      //Prueba que el metodo ReceiveAttack modifica la vida
        {
            int initialLife = gimli.Health;
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            gimli.ReceiveAttack(legolas.AttackValue);

            Assert.AreNotEqual(initialLife, gimli.Health);
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
            gimli.ReceiveAttack(legolas.AttackValue);

            Assert.AreEqual(gimli.Health, 0);
        }

        [Test]
        public void Attack_Doesnt_Heal()                //Prueba que el metodo ReceiveAttack no cura si el ataque es menor a la defensa 
        {
            int initialLife = gimli.Health;
            gimli.ReceiveAttack(legolas.AttackValue);

            Assert.AreEqual(initialLife, gimli.Health);
        }

        [Test]
        public void Healyh_Is_Modified_By_Cure()        //Prueba que el metodo Cure modifica la vida
        {
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            legolas.AddItem(bow);
            gimli.ReceiveAttack(legolas.AttackValue);
            int actualLife = gimli.Health;
            gimli.Cure();

            Assert.AreNotEqual(actualLife, gimli.Health);
        }

        [Test]
        public void Gimli_Damage()                    //Prueba que la suma del daño del personaje es correcto
        {
            Assert.AreEqual(gimli.AttackValue, gimli.AttackValue);
        }

        [Test]
        public void Gimli_Defense()                   //Prueba que la suma de la defensa del personaje es correcta
        {
            int defense = helmet.DefenseValue + shield.DefenseValue;
            Assert.AreEqual(gimli.DefenseValue, defense);
        }
    }
}
