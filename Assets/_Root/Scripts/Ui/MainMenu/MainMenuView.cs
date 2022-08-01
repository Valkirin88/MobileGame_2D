using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;

        [SerializeField] private Button _buttonSettings;

        [SerializeField] private Button _buttonRewardedAds;

       
        public void Init(UnityAction startGame, UnityAction showSettings, UnityAction showAds)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(showSettings);
            _buttonRewardedAds.onClick.AddListener(showAds);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonRewardedAds.onClick.RemoveAllListeners();
        }
    }
}
