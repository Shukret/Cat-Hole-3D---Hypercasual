using System;
using Game.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class GameAssets : MonoBehaviour
    {
        public static GameAssets i;
        [Header("UI")]
        public DefeatUI defeatedUi;
        public FinishUI finishUi;
        
        public void Awake()
        {
            Destroy(i);
            
            i = this;
        }
    }
}