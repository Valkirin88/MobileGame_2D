using Profile;
using Tool;
using UnityEngine;
using UnityEngine.Analytics;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, ShowSettings, ShowAds, BuyProductMenu);
            
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _view.AnalyticsManager.SendGameStartedEvent();
        }
        
        private void ShowSettings() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

        private void ShowAds() =>
            _profilePlayer.CurrentState.Value = GameState.Ads;

        private void BuyProductMenu() =>
            _profilePlayer.CurrentState.Value = GameState.Buy;
    }
}
