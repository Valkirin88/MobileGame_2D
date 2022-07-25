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

        [SerializeField] private Button _buttonBuyProduct;

        public void Init(UnityAction startGame, UnityAction showSettings, UnityAction showAds, UnityAction buyProductMenu)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(showSettings);
            _buttonRewardedAds.onClick.AddListener(showAds);
            _buttonBuyProduct.onClick.AddListener(buyProductMenu);

        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonRewardedAds.onClick.RemoveAllListeners();
            _buttonBuyProduct.onClick.RemoveAllListeners();
        }
    }
}
