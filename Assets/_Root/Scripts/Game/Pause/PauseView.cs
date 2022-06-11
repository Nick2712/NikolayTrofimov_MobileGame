using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class PauseView : MonoBehaviour
    {
        [field: SerializeField] public Button PauseButton { get; private set; }
        [field: SerializeField] public Button ReturnToMainMenuButton { get; private set; }
        [field: SerializeField] public Button ContinueButton { get; private set; }
        [field: SerializeField] public GameObject MenuPausePrefab { get; private set; }
    }
}
