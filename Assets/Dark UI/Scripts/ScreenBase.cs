using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.UI;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }

public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typer> listOfPhrases;

        public Image uiBackground;

        public bool startHide = false;

        [Header("Animation")]
        public float animationduration = .3f;
        public float delayBetweenObjects = .05f;

        private void Start()
        {
            if (startHide)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Show");
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            for(int i =0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationduration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
            uiBackground.enabled = true;
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }
    }

}
