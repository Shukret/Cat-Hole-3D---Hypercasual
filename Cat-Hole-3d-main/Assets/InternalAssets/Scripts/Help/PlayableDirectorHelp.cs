using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Help
{
    public static class PlayableDirectorHelp
    {
        public static void Bind(this PlayableDirector director, string trackName, Animator animator)
        {
            var timeline = director.playableAsset as TimelineAsset;
            foreach (var track in timeline.GetOutputTracks())
            {
                if (track.name == trackName)
                {
                    director.SetGenericBinding(track, animator);
                    break;
                }
            }
        }
        
        public static Object GetBindOrNull(this PlayableDirector director, string trackName)
        {
            var timeline = director.playableAsset as TimelineAsset;
            foreach (var track in timeline.GetOutputTracks())
            {
                if (track.name == trackName)
                {
                    return director.GetGenericBinding(track);
                }
            }

            return null;
        }
    }
}