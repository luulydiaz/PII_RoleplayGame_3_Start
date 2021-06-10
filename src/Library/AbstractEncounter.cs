using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class AbstractEncounter
    {
        public AbstractEncounter(List<AbstractHero> heroes, List<AbstractEnemy> enemies)
        {
            this.Heroes = heroes;
            this.Enemies = enemies;
        }

        public List<AbstractHero> Heroes { get; private set; }
        public List<AbstractEnemy> Enemies { get; private set; }
        public abstract void DoEncounter();
    }
}