using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Level : MonoBehaviour
    {
        public Finish finish;
        public Transform start;

        public Color fogColor;
        
        private void Awake()
        {
            RenderSettings.fogColor = fogColor;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(start.position, 0.5f);
        }
#endif
    }
}