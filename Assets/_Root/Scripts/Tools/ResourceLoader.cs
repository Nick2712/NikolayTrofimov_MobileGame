using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal static class ResourceLoader
    {
        public static GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }

        public static Sprite LoadSprite(string path)
        {
            return Resources.Load<Sprite>(path);
        }
    }
}
