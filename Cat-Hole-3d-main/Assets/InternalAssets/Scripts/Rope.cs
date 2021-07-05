using System;
using UnityEngine;

namespace Game
{
    public class Rope : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        [Space]
        public Transform target;

        private void Update()
        {
            lineRenderer.SetPosition(1, target.position);
        }
    }
}