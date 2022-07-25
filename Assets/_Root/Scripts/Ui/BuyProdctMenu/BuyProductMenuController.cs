using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class BuyProductMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/BuyProductMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly BuyProductMenuView _view;


        public BuyProductMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(ShowMainMenu);
        }

        private BuyProductMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            return objectView.GetComponent<BuyProductMenuView>();
        }

        private void ShowMainMenu() =>
            _profilePlayer.CurrentState.Value = GameState.Start;
    }
}

