using MoreMountains.Feedbacks;
using UnityEngine;

namespace Help
{
    public class RandomRotationForAllChildrens : MonoBehaviour
    {
        public Vector3 vectors;
        
        public float fromRange;
        public float toRange;

        public string[] startWithName;
        
        [MMFInspectorButton("Set")]
        public bool setButton;
        
        public void Set()
        {
            var childrens = GetComponentsInChildren<Transform>();
            for (int rendererIndex = 0; rendererIndex < childrens.Length; rendererIndex++)
            {
                var children = childrens[rendererIndex];
                var continueThis = false;
                for (int startWithNameIndex = 0; startWithNameIndex < startWithName.Length; startWithNameIndex++)
                {
                    if (children.name.StartsWith(startWithName[startWithNameIndex]))
                    {
                        var euler = children.rotation.eulerAngles;
                        euler += vectors * Random.Range(fromRange, toRange);
                        children.rotation = Quaternion.Euler(euler);
                    }
                }
            }
        }
    }
}