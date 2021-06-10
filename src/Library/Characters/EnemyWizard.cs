using System.Collections.Generic;

namespace RoleplayGame
{
    public class EnemyWizard : AbstractMagicEnemy
    {
        public EnemyWizard(string name) : base(name)
        {
        }

        public override int VPs
        {
            get
            {
                return 8;
            }
        }
    }
}