using System;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game
{
    public class LevelTest : MonoBehaviour
    {
        [FormerlySerializedAs("prefab")] public GameObject levelPrefab;
        [FormerlySerializedAs("prefab")] public GameObject finishPrefab;

        public int floors;
        public float offset;

        private void Start()
        {
            Build();
        }

        [ContextMenu("Build")]
        public void Build()
        {
            transform.MMDestroyAllChildren();
            
            var finishObj = Instantiate(finishPrefab, transform);
            finishObj.transform.position = Vector3.zero;
            
            var floor = 1;
            for ( ; floor < floors; floor++)
            {
                var levelObj = Instantiate(levelPrefab, transform);
                levelObj.transform.position += offset * floor * Vector3.up;
            }
        }
    }
}