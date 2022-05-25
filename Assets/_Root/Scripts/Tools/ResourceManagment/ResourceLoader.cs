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

        public static TResource LoadResource<TResource>(string path) where TResource : Object
        {
            return Resources.Load<TResource>(path);
        }
    }
}
