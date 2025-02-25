using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace TowerDefense
{
    public class TextUpdate : MonoBehaviour
    {
        public enum UpdateSource { Gold, Life}
        public UpdateSource source = UpdateSource.Gold;

        private TextMeshProUGUI m_text;

        void Awake()
        {
            m_text = GetComponent<TextMeshProUGUI>();
            switch (source)
            {
                case UpdateSource.Gold:
                    TDPlayer.OnGoldUpdate += UpdateText;
                    break;

                 case UpdateSource.Life:
                    TDPlayer.OnLifeUpdate += UpdateText;
                    break;
            }
        }
        private void UpdateText(int money)
        {
            m_text.text = money.ToString();
        }
    }
}


