using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace Game
{
    public class Wood : MonoBehaviour
    {
        public GameObject startPart;
        public GameObject part;

        public Material material;
        
        public int count;

        public float offset;
        
        [MMFInspectorButton("Create")]
        public bool createButton;
        
        public void Create()
        {
            transform.MMDestroyAllChildren();
            
            var startPartObj = Instantiate(startPart, transform);
            startPartObj.transform.localPosition = Vector3.zero;
            startPartObj.GetComponent<Renderer>().material = material;

            for (int partIndex = 1; partIndex < count; partIndex++)
            {
                var partObj = Instantiate(part, transform);
                var pos = new Vector3(0, partIndex * offset, 0);
                partObj.transform.localPosition = pos;
                partObj.GetComponent<Renderer>().material = material;
            }
        }
    }
}