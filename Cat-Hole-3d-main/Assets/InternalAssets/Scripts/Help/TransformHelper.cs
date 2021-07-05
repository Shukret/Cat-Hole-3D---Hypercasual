using UnityEngine;

namespace Help
{
    public class TransformHelper : MonoBehaviour
    {
        public Transform source;
        
        public void SetX(float x)
        {
            var pos = source.position;
            pos.x = x;
            source.position = pos;
        }
        
        public void SetY(float y)
        {
            var pos = source.position;
            pos.y = y;
            source.position = pos;
        }
        
        public void SetZ(float z)
        {
            var pos = source.position;
            pos.z = z;
            source.position = pos;
        }
        
        public void SetLocalX(float x)
        {
            var pos = source.localPosition;
            pos.x = x;
            source.localPosition = pos;
        }
        
        public void SetLocalY(float y)
        {
            var pos = source.localPosition;
            pos.y = y;
            source.localPosition = pos;
        }
        
        public void SetLocalZ(float z)
        {
            var pos = source.localPosition;
            pos.z = z;
            source.localPosition = pos;
        }
    }
}