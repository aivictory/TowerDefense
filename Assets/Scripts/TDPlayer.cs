using UnityEngine;
using SpaceShooter;
using System;
using UnityEngine.UIElements;

namespace TowerDefense
{
    public class TDPlayer : Player
    {
        public static new TDPlayer Instance
        { get
            {
                return Player.Instance as TDPlayer;
            }
        }
        private static event Action<int> OnGoldUpdate;
        public static void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_gold);
        }
        private static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.NumLives);
        }
        [SerializeField] private int m_gold = 0;
      
        public void ChangeGold(int change)
        {
            m_gold += change;
            OnGoldUpdate(m_gold);

        }

        public void ReduceLife(int change)
        {
            TakeDamage(change);
            OnLifeUpdate(NumLives);

        }

        [SerializeField] private Tower m_towerPrefab;

   
        public void TryBuild(TowerAsset towerAsset, Transform buildSite)
        {
            ChangeGold(-towerAsset.goldCost);
            var tower = Instantiate(m_towerPrefab,buildSite.position, Quaternion.identity);
            tower.GetComponentInChildren<SpriteRenderer>().sprite = towerAsset.Sprite;
            Destroy(buildSite.gameObject);
            
        }
    }
}


