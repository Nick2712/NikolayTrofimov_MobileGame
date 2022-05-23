namespace NikolayTrofimov_MobileGame
{
    internal sealed class StubAbility : IAbility
    {
        public static readonly IAbility Default = new StubAbility();

        public void Apply(IAbilityActivator activator)
        { 
        }
    }
}
