using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using Game.Player;
using Game.UI;
using Help;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using GameAnalyticsSDK;

namespace Game
{
    public class Finish : MonoBehaviour
    {
        public PlayerController player;
        public Transform playerTransform;
        
        [FormerlySerializedAs("playableDirector")] public PlayableDirector finishPlayableDirector;
        public PlayableDirector dogsPlayableDirector;
        public Transform startAnimation;

        private bool isFinished;

        private void Start()
        {
            GameAnalytics.Initialize();
            player = PlayerController.current;
            playerTransform = player.gameObject.transform;
            
            finishPlayableDirector.Bind("Player", player.GetComponent<Animator>());
            finishPlayableDirector.Bind("CatTransform", player.mainAnimator);
            finishPlayableDirector.Bind("CatAnimations", player.mainAnimator);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!isFinished)
                {
                    isFinished = true;

                    GameAnalytics.NewProgressionEvent (GAProgressionStatus.Complete, ("Level" + (LevelController.currentLevelIndex+1).ToString()));

                    other.GetComponent<PlayerMovement>().fallSpeed = 0f;

                    other.transform.DOMove(startAnimation.position, 0.25f).OnComplete(() =>
                    {
                        finishPlayableDirector.Play();
                        dogsPlayableDirector.Play();
                    });
                }
                
                finishPlayableDirector.stopped += FinishPlayableDirectorOnStopped;
                
                GameEvents.ChangeGameState(GameState.Finish);
            }
        }

        private void FinishPlayableDirectorOnStopped(PlayableDirector playableDirector)
        {
            FinishUI.Create();
            AudioController.PlayAction(AudioAction.Finish);
        }

        public float GetDistanceAtPlayer()
        {
            return playerTransform.position.y - transform.position.y;
        }
    }
}