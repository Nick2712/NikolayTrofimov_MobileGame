using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal interface IAbilityItem
    {
        string Id { get; }
        Sprite Icon { get; }
        AbilityType Type { get; }
        GameObject Projectile { get; }
        float Value { get; }
    }
}
