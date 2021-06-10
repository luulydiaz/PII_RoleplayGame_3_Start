using System.Collections.Generic;

namespace RoleplayGame
{
    public class EnemyArcher : AbstractEnemy
    {
        public EnemyArcher (string name) : base(name)
        {
        }

        public override int VPs
        {
            get
            {
                return 6;
            }
        }
    }
}