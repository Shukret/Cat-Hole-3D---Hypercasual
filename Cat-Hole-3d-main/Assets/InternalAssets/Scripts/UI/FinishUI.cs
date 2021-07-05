using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    public class FinishUI : MonoBehaviour
    {
        public CanvasGroup canvasGroup;

        public RectTransform panel;

        public Button button;
        
        public static FinishUI Create()
        {
            var effect = Instantiate(GameAssets.i.finishUi);
            
            return effect;
        }

        private void Start()
        {
            button.onClick.AddListener(()=> SceneManager.LoadScene("Game"));
        }

        private void OnEnable()
        {
            canvasGroup.DOFade(1, .5f);
            panel.transform.DOScale(1, .5f);
        }
        
    }
}