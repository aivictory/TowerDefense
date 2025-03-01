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

        void Start()
        {
            m_text = GetComponent<TextMeshProUGUI>();
            switch (source)
            {
                case UpdateSource.Gold:
                    TDPlayer.GoldUpdateSubscribe(UpdateText);
                    break;

                 case UpdateSource.Life:
                    TDPlayer.LifeUpdateSubscribe(UpdateText);
                    break;
            }
        }
        private void UpdateText(int money)
        {
            m_text.text = money.ToString();
        }
    }
}


