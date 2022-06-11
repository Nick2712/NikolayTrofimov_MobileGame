using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class CrimeListener : IEnemy
    {
        private const int ADMISSIBLE_CRIME_COUNT = 2;

        private readonly Button _passPeacefully;
        
        public CrimeListener(Button passPeacefully)
        {
            _passPeacefully = passPeacefully;
        }

        public void Update(PlayerData dataPlayer)
        {
            if (dataPlayer.DataType == DataType.Crime)
            {
                if(dataPlayer.Value > ADMISSIBLE_CRIME_COUNT)
                {
                    _passPeacefully.gameObject.SetActive(false);
                }
                else
                {
                    _passPeacefully.gameObject.SetActive(true);
                }

                Debug.Log($"Notified {nameof(CrimeListener)} change to {dataPlayer.DataType}");
            }
        }
    }
}
