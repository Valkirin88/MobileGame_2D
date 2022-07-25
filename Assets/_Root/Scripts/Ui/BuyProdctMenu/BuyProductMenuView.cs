using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class BuyProductMenuView : MonoBehaviour
    {
        public Button _buttonBack;

        public void Init(UnityAction showMainMenu) =>
            _buttonBack.onClick.AddListener(showMainMenu);

        public void OnDestroy() =>
            _buttonBack.onClick.RemoveAllListeners();
    }
}
