using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreens = ScreenType.Panel;

        private ScreenBase _currentscreen;

        private void Start()
        {
            transform.Scale(2);
            HideAll();
            ShowByType(startScreens);
        }

        private void GetRandom()
        {
            screenBases[Random.Range(0, screenBases.Count)].animationduration = 1;
        }

        public void ShowByType(ScreenType type)
        {
            if (_currentscreen != null)
            {
                _currentscreen.Hide();
            }
               
            var nextScreen = screenBases.Find(i => i.screenType == type);

            nextScreen.Show();
            _currentscreen = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }

}


