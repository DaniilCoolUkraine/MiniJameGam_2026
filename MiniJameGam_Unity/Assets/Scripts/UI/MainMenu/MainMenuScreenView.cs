using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace MiniJameGam.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            GlobalEvents.Publish(new MainMenuPlayButtonClickedEvent());
        }
    }
}
