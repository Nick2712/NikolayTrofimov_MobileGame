using System;


namespace NikolayTrofimov_MobileGame
{
    internal static class UpdateManager
    {
        public static event Action<float> UpdateAction;
        public static event Action<float> FixedUpdateAction;

        public static void Update(float deltaTime)
        {
            UpdateAction?.Invoke(deltaTime);
        }

        public static void FixedUpdate(float fixedDeltaTime)
        {
            FixedUpdateAction?.Invoke(fixedDeltaTime);
        }
    }
}
