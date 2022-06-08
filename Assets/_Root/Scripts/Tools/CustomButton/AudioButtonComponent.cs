using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    internal sealed class AudioButtonComponent : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;


        private void OnValidate() => InitComponents();
        private void Awake() => InitComponents();

        private void Start() => _button.onClick.AddListener(OnButtonClick);

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _audioSource ??= GetComponent<AudioSource>();
        }

        private void OnButtonClick() => ActivateSound();
        private void ActivateSound() => _audioSource.Play();

        private void OnDestroy() => _button.onClick.RemoveAllListeners();
    }
}
