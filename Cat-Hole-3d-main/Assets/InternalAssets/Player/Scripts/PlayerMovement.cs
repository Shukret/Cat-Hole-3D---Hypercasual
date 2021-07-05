using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public Transform body;
        
        public float fallSpeed;
        public float fallModifer;
        public float smoothTime;
        public float nearClipPlane;
        public float range;
        
        private Camera _cameraMain;
        private Vector3 _movePosition;
        private Vector3 _velocity;

        private void Awake()
        {
            _cameraMain = Camera.main;
        }
        
        private void OnEnable()
        {
            TouchSimulation.Enable();
            EnhancedTouchSupport.Enable();
            
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += Move;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove += Move;

            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.y = 0;
            transform.DORotate(eulerAngles,1f).SetEase(Ease.InOutSine);
        }

        private void OnDisable()
        {
            TouchSimulation.Disable();
            EnhancedTouchSupport.Disable();

            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= Move;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove -= Move;
        }
        
        private void Move(Finger finger)
        {
            var screenPos = new Vector3(finger.screenPosition.x, finger.screenPosition.y, nearClipPlane);
            var pos = _cameraMain.ScreenToWorldPoint(screenPos);
            pos.y = 0;

            pos = Vector3.ClampMagnitude(pos, range);

            _movePosition = pos;
        }

        private void Update()
        {
            if (fallSpeed > 0)
            {
                var plr = transform;
                var plrPos = plr.position;
                
                var newPos = Vector3.SmoothDamp(plrPos, _movePosition, ref _velocity, smoothTime);
                newPos.y = plrPos.y - fallSpeed * Time.deltaTime;

                fallSpeed += fallModifer * Time.deltaTime;
                
                plr.position = newPos;
            }
        }
    }
}