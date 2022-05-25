using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class AbilitiesRepository : Repository<string, IAbility, AbilityItemConfig>, IAbilitiesRepository
    {
        public AbilitiesRepository(IEnumerable<AbilityItemConfig> configs) : base(configs)
        {
        }

        protected override string GetKey(AbilityItemConfig config)
        {
            return config.Id;
        }

        protected override IAbility CreateItem(AbilityItemConfig config)
        {
            return config.Type switch
            {
                AbilityType.Gun => new GunAbility(config),
                _ => StubAbility.Default
            };
        }
    }
}
