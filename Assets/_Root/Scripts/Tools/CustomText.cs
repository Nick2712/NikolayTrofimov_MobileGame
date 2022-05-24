using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    public class CustomText : MonoBehaviour
    {
        [SerializeField] private Component _text;
        
        public string Text
        {
            get
            {
                return GetText();
            }
            set
            {
                SetText(value);
            }
        }


        private void OnValidate()
        {
            Initialize();
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (!(_text is Text) && !(_text is TextMeshProUGUI))
            {
                _text = null;
                throw new UnityException("Can't attach any text component!");
            }
        }

        private void SetText(string value)
        {
            if (_text is TextMeshProUGUI textMeshPro)
            {
                textMeshPro.text = value;
            }
            if (_text is Text text)
            {
                text.text = value;
            }
        }

        private string GetText()
        {
            if (_text is TextMeshProUGUI textMeshPro)
            {
                return textMeshPro.text;
            }
            if (_text is Text text)
            {
                return text.text;
            }
            return "";
        }
    }
}
