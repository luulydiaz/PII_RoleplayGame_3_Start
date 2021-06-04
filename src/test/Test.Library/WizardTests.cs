// using NUnit.Framework;
// using RoleplayGame;
// using System;


// namespace Test.Library
// {
//     public class WizardTests
//     {
//         private Wizard gandalf;
//         private Staff staff;
//         private SpellsBook spellsBook;
//         private Wizard saruman;
//         private Staff sarumanStaff;
//         private SpellsBook sarumanSpellsBook;

//         [SetUp]
//         public void Setup()
//         {
//             this.gandalf = new Wizard("Gandalf");
//             this.staff = new Staff();
//             this.spellsBook= new SpellsBook();
//             spellsBook.Spells = new Spell[] { new Spell() };
//             gandalf.AddItem(staff);
//             gandalf.AddItem(spellsBook);

//             this.saruman = new Wizard("Saruman");
//             this.sarumanStaff = new Staff();
//             this.sarumanSpellsBook= new SpellsBook();
//             sarumanSpellsBook.Spells = new Spell[] { new Spell() };
            

//         }

//         [Test]
//         public void Health_Is_Modified_By_Attack()      //Prueba que el metodo ReceiveAttack modifica la vida
//         {
//             saruman.AddItem(sarumanSpellsBook);
//             saruman.AddItem(sarumanStaff);
//             saruman.AddItem(sarumanStaff);
//             int initialLife = gandalf.Health;
//             gandalf.ReceiveAttack(saruman);

//             Assert.AreNotEqual(initialLife, gandalf.Health);
//         }

//         [Test]
//         public void Health_Doesnt_Drop_Below_Zero()     //Prueba que la vida no puede bajar de cero
//         {
//             saruman.AddItem(sarumanSpellsBook);
//             saruman.AddItem(sarumanStaff);
//             saruman.AddItem(sarumanStaff);
//             saruman.AddItem(sarumanStaff);
//             gandalf.ReceiveAttack(saruman);

//             Assert.AreEqual(gandalf.Health, 0);
//         }

//         [Test]
//         public void Attack_Doesnt_Heal()                //Prueba que el metodo ReceiveAttack no cura si el ataque es menor a la defensa 
//         {
//             saruman.AddItem(sarumanSpellsBook);
//             int initialLife = gandalf.Health;
//             gandalf.ReceiveAttack(saruman);

//             Assert.AreEqual(initialLife, gandalf.Health);
//         }

//         [Test]
//         public void Healyh_Is_Modified_By_Cure()        //Prueba que el metodo Cure modifica la vida
//         {
//             saruman.AddItem(sarumanSpellsBook);
//             saruman.AddItem(sarumanStaff);
//             saruman.AddItem(sarumanSpellsBook);
//             gandalf.ReceiveAttack(saruman);
//             int actualLife = gandalf.Health;
//             gandalf.Cure();

//             Assert.AreNotEqual(actualLife, gandalf.Health);
//         }

//         [Test]
//         public void Character_Doesnt_Revive()           //Prueba que el personaje no puede revivir 
//         {
//             saruman.AddItem(sarumanSpellsBook);
//             saruman.AddItem(sarumanStaff);
//             saruman.AddItem(sarumanStaff);
//             saruman.AddItem(sarumanStaff);
//             gandalf.ReceiveAttack(saruman);
//             int actualHealt = gandalf.Health;
//             gandalf.Cure();

//             Assert.AreEqual(actualHealt, gandalf.Health);
//         }

//         [Test]
//         public void Gandalf_Damage()                    //Prueba que la suma del daño del personaje es correcto
//         {
//             int attack = staff.AttackValue + spellsBook.AttackValue;

//             Assert.AreEqual(gandalf.AttackValue, attack);
//         }

//         [Test]
//         public void Gandalf_Defense()                   //Prueba que la suma de la defensa del personaje es correcta
//         {
//             int defense = staff.AttackValue + spellsBook.AttackValue;
//             Assert.AreEqual(gandalf.DefenseValue, defense);
//         }
//     }
// }
