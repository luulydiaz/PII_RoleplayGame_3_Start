using System.Collections.Generic;

namespace RoleplayGame
{
    public class BadWizard : AbstractMagicEnemy
    {
        public BadWizard(string name) : base(name)
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