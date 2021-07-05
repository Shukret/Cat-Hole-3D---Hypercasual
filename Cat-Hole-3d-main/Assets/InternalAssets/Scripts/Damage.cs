using System;
using UnityEngine;
using UnityEngine.Events;
using GameAnalyticsSDK;

namespace Game
{
    public class Damage : MonoBehaviour
    {
        public string colliderTag = "Player";
        public UnityEvent damaged;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(colliderTag))
            {
                GameAnalytics.NewProgressionEvent (GAProgressionStatus.Fail, ("Level" + (LevelController.currentLevelIndex+1).ToString()));

                other.GetComponent<IDamageable>().Damage();
                
                damaged?.Invoke();
            }
        }
    }
}