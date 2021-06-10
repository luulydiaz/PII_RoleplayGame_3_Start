using NUnit.Framework;
using RoleplayGame;


namespace Test.Library
{
    public class ArcherTests
    {
        private Archer legolas;
        private Wizard nurgargan;
        private Helmet helmet;
        private Bow bow;
        private Shield shield;
        private Staff staff;
        private SpellsBook book;


        [SetUp]
        public void Setup()
        {
            this.legolas = new Archer("Legolas");
            this.bow = new Bow();
            this.helmet = new Helmet();
            this.shield = new Shield();
            legolas.AddItem(bow);
            legolas.AddItem(helmet);
            legolas.AddItem(shield);

            this.nurgargan = new Wizard("Nurgargan");
            this.staff = new Staff();
            this.book = new SpellsBook();
            book.AddSpell(new SpellOne());
            nurgargan.AddItem(staff);
            nurgargan.AddItem(book);
        }

        [Test]
        public void Health_Is_Modified_By_Attack()      //Prueba que el metodo ReceiveAttack modifica la vida
        {
            int initialLife = legolas.Health;
            legolas.ReceiveAttack(nurgargan.AttackValue);

            Assert.AreNotEqual(initialLife, legolas.Health);
        }

        [Test]
        public void Health_Doesnt_Drop_Below_Zero()     //Prueba que la vida no puede bajar de cero
        {
            legolas.ReceiveAttack(nurgargan.AttackValue);

            Assert.AreEqual(legolas.Health, 0);
        }

        [Test]
        public void Attack_Doesnt_Heal()                //Prueba que el metodo ReceiveAttack no cura si el ataque es menor a la defensa 
        {
            int initialLife = legolas.Health;
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.ReceiveAttack(nurgargan.AttackValue);

            Assert.AreEqual(initialLife, legolas.Health);
        }

        [Test]
        public void Healyh_Is_Modified_By_Cure()        //Prueba que el metodo Cure modifica la vida
        {
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.AddItem(helmet);
            legolas.ReceiveAttack(nurgargan.AttackValue);
            int actualLife = legolas.Health;
            legolas.Cure();

            Assert.AreNotEqual(actualLife, legolas.Health);
        }

        [Test]
        public void Legolas_Damage()                    //Prueba que la suma del daño del personaje es correcto
        {
            Assert.AreEqual(legolas.AttackValue, bow.AttackValue);
        }

        [Test]
        public void Legolas_Defense()                   //Prueba que la suma de la defensa del personaje es correcta
        {
            int defense = helmet.DefenseValue + shield.DefenseValue;
            Assert.AreEqual(legolas.DefenseValue, defense);
        }
    }
}
