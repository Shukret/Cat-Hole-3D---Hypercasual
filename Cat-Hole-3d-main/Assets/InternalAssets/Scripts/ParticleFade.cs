using UnityEngine;

namespace Game
{
    public class ParticleFade : MonoBehaviour
    {
        public ParticleSystem particleSystem;
        public Finish finish;

        public float fadeDistance;
        public float fadeOffset;

        private bool _stop = false;
        private void Update()
        {
            if (_stop) return;

            if (finish)
            {
                var dist = finish.GetDistanceAtPlayer();
                if (dist + fadeOffset < fadeDistance)
                {
                    var fade = (dist - fadeOffset) / fadeDistance;

                    var psMain = particleSystem.main;
                
                    var color = psMain.startColor.color;
                    color.a = fade;
                
                    if (fade < 0.1f)
                    {
                        _stop = true;
                    
                        color.a = 0;
                
                        particleSystem.Stop();
                    }
                
                    psMain.startColor = color;
                }
            }
        }
    }
}