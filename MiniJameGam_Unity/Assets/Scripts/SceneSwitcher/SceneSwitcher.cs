using System;
using System.Collections.Generic;
using MiniJameGam.UI.MainMenu;
using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniJameGam.SceneSwitcher
{
    // TODO: consider moving it to non-monobehaviour class
    public class SceneSwitcher : MonoBehaviour
    {
        private static readonly Dictionary<Type, string> EventToSceneName = new()
        {
            { typeof(MainMenuPlayButtonClickedEvent), "PlayScene" }
        };
        
        private void OnEnable()
        {
            GlobalEvents.AddListener<MainMenuPlayButtonClickedEvent>(OnPlayButtonClicked);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<MainMenuPlayButtonClickedEvent>(OnPlayButtonClicked);
        }

        /*
         * Event Handlers
         */
        
        private void OnPlayButtonClicked(MainMenuPlayButtonClickedEvent obj)
        {
            if (EventToSceneName.TryGetValue(typeof(MainMenuPlayButtonClickedEvent), out var scene))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}