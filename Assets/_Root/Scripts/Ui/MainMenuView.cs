using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        
        [SerializeField] private Button _buttonSettings;
                
        public void Init(UnityAction startGame) =>
            _buttonStart.onClick.AddListener(startGame);

        public void InitSettings(UnityAction settings) =>
            _buttonSettings.onClick.AddListener(settings);

        public void OnDestroy() =>
            _buttonStart.onClick.RemoveAllListeners();
    }
}
