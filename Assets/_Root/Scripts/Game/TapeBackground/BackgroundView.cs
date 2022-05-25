using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    public class BackgroundView : MonoBehaviour
    {
        [SerializeField] private BackgroundPartView[] _backgroundParts;

        public void Move(float value)
        {
            for (int i = 0; i < _backgroundParts.Length; i++)
                _backgroundParts[i].Move(value);
        }
    }
}
