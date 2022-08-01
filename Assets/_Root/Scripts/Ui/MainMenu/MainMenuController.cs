using Profile;
using Services.Ads.UnityAds;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly UnityAdsService _adsService;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, UnityAdsService adsService)
        {
            _profilePlayer = profilePlayer;
            _adsService = adsService;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, ShowSettings, ShowAds);
            
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()=>
            _profilePlayer.CurrentState.Value = GameState.Game;
        
        
        private void ShowSettings() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

        private void ShowAds()
        {
            if (_adsService.IsInitialized)
                OnAdsInitialized();
            
            else
                _adsService.Initialized.AddListener(OnAdsInitialized);
        }

        protected override void OnDispose()
        {
            _adsService.Initialized.RemoveListener(OnAdsInitialized);
        }

        private void OnAdsInitialized() => _adsService.RewardedPlayer.Play();
    }
}
