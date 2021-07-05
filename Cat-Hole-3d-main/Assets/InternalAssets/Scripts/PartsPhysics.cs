using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class PartsPhysics : MonoBehaviour
    {
        public Rigidbody[] parts;
        public Transform explosion;
        public float radius;
        public void UsePhysics()
        {
            for (int partIndex = 0; partIndex < parts.Length; partIndex++)
            {
                parts[partIndex].isKinematic = false;
            }
        }

        public void Explosion(float force)
        {
            for (int partIndex = 0; partIndex < parts.Length; partIndex++)
            {
                var part  = parts[partIndex];
                part.AddExplosionForce(force, explosion.position, radius);
                part.transform.DOScale(Vector3.zero, 1f).SetDelay(0.5f).OnComplete(() =>
                {
                    Destroy(part.gameObject);
                });
            }
        }
    }
}