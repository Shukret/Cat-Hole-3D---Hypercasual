using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game
{
    public class Trigger : MonoBehaviour
    {
        public string colliderTag;
        public UnityEvent onEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(colliderTag))
            {
                onEnter?.Invoke();
            }
        }
    }
}