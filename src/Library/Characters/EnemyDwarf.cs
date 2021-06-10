using System.Collections.Generic;

namespace RoleplayGame
{
    public class EnemyDwarf : AbstractEnemy
    {
        public EnemyDwarf(string name) : base(name)
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