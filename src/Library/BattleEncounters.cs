using System.Collections.Generic;
using System.Linq;

namespace RoleplayGame
{
    public class BattleEncounter : AbstractEncounter
    {
        private Dictionary<AbstractHero, int> initialHeroesVPs;
        public BattleEncounter(List<AbstractHero> heroes, List<AbstractEnemy> enemies) : base(heroes, enemies)
        {

        }

        public bool FightIsOver
        {
            get
            {
                return this.HeroesAlive().Count() == 0 || this.EnemiesAlive().Count() == 0;
            }
        }

        public List<AbstractHero> HeroesAlive()
        {
            List<AbstractHero> HeroesAlive = new List<AbstractHero>();
            foreach (AbstractHero hero in this.Heroes)
            {
                if (hero.IsAlive)
                {
                    HeroesAlive.Add(hero);
                }
            }
            return HeroesAlive;
        }

        public List<AbstractEnemy> EnemiesAlive()
        {
            List<AbstractEnemy> EnemiesAlive = new List<AbstractEnemy>();
            foreach (AbstractEnemy enemy in this.Enemies)
            {
                if (enemy.IsAlive)
                {
                    EnemiesAlive.Add(enemy);
                }
            }
            return EnemiesAlive;
        }

        public override void DoEncounter()
        {
            this.SaveInitialHeroVPs();

            while (!this.FightIsOver)
            {
                this.EnemiesAttack();
                this.HeroesAttack();
            }

            this.CureHeroes();
        }


        private void HeroesAttack()
        {
            foreach (AbstractEnemy enemy in this.EnemiesAlive())
            {
                foreach (AbstractHero hero in this.HeroesAlive())
                {
                    enemy.ReceiveAttack(hero.AttackValue);
                    if (!enemy.IsAlive)
                    {
                        hero.CollectVPs(enemy.VPs);
                        break;
                    }
                }
            }
        }

        private void EnemiesAttack()
        {
            List<AbstractHero> heroesToAttack = new List<AbstractHero>(HeroesAlive());
            int currentIndex = 0;
            foreach (AbstractEnemy enemy in this.EnemiesAlive())
            {
                if (heroesToAttack.Count == 0)
                {
                    return;
                }

                AbstractHero hero = heroesToAttack.ElementAt(currentIndex);
                hero.ReceiveAttack(enemy.AttackValue);

                if (!hero.IsAlive)
                {
                    heroesToAttack.Remove(hero);
                    if (currentIndex == heroesToAttack.Count)
                    {
                        currentIndex = 0;
                    }
                }
                else
                {
                    if (currentIndex == heroesToAttack.Count() - 1)
                    {
                        currentIndex = 0;
                    }
                    else
                    {
                        currentIndex = currentIndex + 1;
                    }
                }
            }
        }

        private void SaveInitialHeroVPs()
        {
            this.initialHeroesVPs = new Dictionary<AbstractHero, int>();
            foreach(AbstractHero hero in this.Heroes)
            {
                this.initialHeroesVPs.Add(hero, hero.VPsAcumulated);
            }
        }

        private void CureHeroes()
        {
            foreach(AbstractHero hero in this.HeroesAlive())
            {
                if (hero.VPsAcumulated - this.initialHeroesVPs[hero] >= 5)
                {
                    hero.Cure();
                }
            }
        }
    }
}