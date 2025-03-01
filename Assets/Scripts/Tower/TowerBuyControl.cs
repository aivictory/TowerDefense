using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerBuyControl : MonoBehaviour
    {
    
        [SerializeField] private TowerAsset m_Asset;
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private Button m_button;
        [SerializeField] private Transform buildSite;
        public void SetBuildSite(Transform value) 
        { 
            buildSite = value; 
        } 

   
        private void Start() 
        {
            TDPlayer.GoldUpdateSubscribe(GoldStatusCheck);

            m_text.text = m_Asset.goldCost.ToString();
            m_button.GetComponent<Image>().sprite = m_Asset.GUISprite;

        }
        private void GoldStatusCheck(int gold)
        {
            if (gold >= m_Asset.goldCost != m_button.interactable)
            {
                m_button.interactable = !m_button .interactable;
                m_text.color = m_button.interactable ? Color.white : Color.red;
            }
        }
        public void Buy()
        {
            TDPlayer.Instance.TryBuild(m_Asset, buildSite);
            BuildSite.HideControls();
        }



    }

}
