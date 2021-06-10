namespace RoleplayGame
{
    public abstract class AbstractHero: AbstractCharacter
    {

        public AbstractHero(string name) : base(name)
        {
            this.VPsAcumulated = 0;
        }

        public int VPsAcumulated { get; private set; }

        public void CollectVPs(int vps)
        {
            this.VPsAcumulated += vps;
        }
    }
}