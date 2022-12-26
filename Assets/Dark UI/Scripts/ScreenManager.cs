using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Screens
{

    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreens = ScreenType.Panel;

        private ScreenBase _currentscreen;

        private void Start()
        {
            HideAll();
            ShowByType(startScreens);
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


