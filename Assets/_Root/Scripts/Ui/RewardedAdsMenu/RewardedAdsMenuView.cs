using Services.Ads.UnityAds;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class RewardedAdsMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonBack;

        public void Init(UnityAction showMainMenu)
        {
            _buttonBack.onClick.AddListener(showMainMenu);
          
        }

        public void OnDestroy()
        {
            _buttonBack.onClick.RemoveAllListeners();

        }
        
    }
}
