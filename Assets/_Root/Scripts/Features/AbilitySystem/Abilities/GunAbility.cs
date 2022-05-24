using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class GunAbility : IAbility
    {
        private const float LIFE_TIME_PROJECTILE = 2.0f;

        private readonly AbilityItemConfig _config;

        public GunAbility(AbilityItemConfig config)
        {
            _config = config;
        }

        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_config.Projectile).GetComponent<Rigidbody2D>();
            projectile.transform.position = activator.ViewGameObject.transform.position;
            Vector3 force = activator.ViewGameObject.transform.right * _config.Value;
            projectile.AddForce(force, ForceMode2D.Impulse);
            Object.Destroy(projectile.gameObject, LIFE_TIME_PROJECTILE);
        }
    }
}
