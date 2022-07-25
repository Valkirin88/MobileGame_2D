using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class RewardedAdsMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/RewardedAdsMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly RewardedAdsMenuView _view;


        public RewardedAdsMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(ShowMainMenu);
        }

        private RewardedAdsMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            return objectView.GetComponent<RewardedAdsMenuView>();
        }

        private void ShowMainMenu() =>
            _profilePlayer.CurrentState.Value = GameState.Start;
    }
}

