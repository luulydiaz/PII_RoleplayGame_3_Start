namespace RoleplayGame
{
    public abstract class AbstractEnemy: AbstractCharacter
    {
        public AbstractEnemy(string name) : base(name)
        {
        }

        public abstract int VPs { get; }
    }
}