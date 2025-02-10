using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using Common;
using System.Data;

namespace TowerDefence
{
    public class TDPlayer : Player
    {
        [SerializeField] private int m_gold = 0;
        public void ChangeGold(int change)
        {
            m_gold += change;

        }
    }
}


