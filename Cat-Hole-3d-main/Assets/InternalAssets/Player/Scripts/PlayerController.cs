using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Game.UI;
using Help;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        public static PlayerController current;
        
        public PlayerMovement playerMovement;
        public PlayableDirector startPlayableDirector;
        public CinemachineVirtualCamera virtualCamera;
        
        [Header("Feedback")] 
        public MMFeedbacks damageFeedbacks;

        [Header("Sub")] 
        public Animator mainAnimator;
        public TrailRenderer trailRope;
        public ParticleSystem barrierParticleSystem;
        public Material sleepMat;
        public Material actionMat;
        public Renderer[] renderers;
        
        private void Awake()
        {
            current = this;
            
            LevelController.onLevelLoad += LevelControllerOnLevelLoad;
            GameEvents.onGameStateChange += GameEventsOnGameStateChange;
        }

        private void OnDestroy()
        {
            LevelController.onLevelLoad -= LevelControllerOnLevelLoad;
            GameEvents.onGameStateChange -= GameEventsOnGameStateChange;
        }

        private void LevelControllerOnLevelLoad(Level level)
        {
            transform.position = level.start.position;
            transform.rotation = level.start.rotation;
        }

        private void GameEventsOnGameStateChange(GameState state)
        {
            if (state == GameState.Play)
            {
                startPlayableDirector.Play();
                
                virtualCamera.Priority = 10;
                
                trailRope.gameObject.SetActive(true);
                barrierParticleSystem.Play();

                mainAnimator.SetBool("Falling", true);

                for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
                {
                    renderers[rendererIndex].material = actionMat;
                }
                
                AudioController.PlayAction(AudioAction.Start);
            }
        }
        
        private void Start()
        {
            GameEvents.ChangeGameState(GameState.Start);
        }

        public void Damage()
        {
            damageFeedbacks.PlayFeedbacks();
            
            MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, 0, 0.25f, true, 2, true);
            
            var defeatUi = DefeatUI.Create();
            defeatUi.button.onClick.AddListener(() =>
            {
                MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Reset, 1f, 0f, false, 1, true);
            });
            
            AudioController.PlayAction(AudioAction.Fail);
            
            GameEvents.ChangeGameState(GameState.Fail);
        }
    }
}
