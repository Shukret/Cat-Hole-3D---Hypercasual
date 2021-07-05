using System;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Help
{
    public class RendererSetMaterialAllChildrens : MonoBehaviour
    {
        public Material material;

        public string[] startWithName;
        
        [MMFInspectorButton("Set")]
        public bool setButton;
        
        public void Set()
        {
            var renderers = GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                var renderer = renderers[rendererIndex];
                var continueThis = false;
                for (int startWithNameIndex = 0; startWithNameIndex < startWithName.Length; startWithNameIndex++)
                {
                    if (renderer.name.StartsWith(startWithName[startWithNameIndex]))
                    {
                        renderer.material = material;
                    }
                }
            }
        }
    }
}