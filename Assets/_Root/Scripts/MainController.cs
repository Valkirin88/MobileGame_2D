using Ui;
using Game;
using Profile;
using UnityEngine;
using Tool.Analytics;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsMenuController _settingsMenuController;
    private RewardedAdsMenuController _rewardedAdsMenuController;
    private BuyProductMenuController _buyProductMenuController;
    private AnalyticsManager _analyticsManager;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, AnalyticsManager analyticsManager)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _analyticsManager = analyticsManager;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        _buyProductMenuController?.Dispose();
        _rewardedAdsMenuController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _settingsMenuController?.Dispose();
                _gameController?.Dispose();
                _buyProductMenuController?.Dispose();
                _rewardedAdsMenuController?.Dispose();
                break;

            case GameState.Ads:
                _rewardedAdsMenuController = new RewardedAdsMenuController(_placeForUi, _profilePlayer);
                _buyProductMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;

            case GameState.Buy:
                _rewardedAdsMenuController?.Dispose();
                _buyProductMenuController = new BuyProductMenuController(_placeForUi, _profilePlayer);
                _settingsMenuController?.Dispose();
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;

            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _buyProductMenuController?.Dispose();
                _rewardedAdsMenuController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _buyProductMenuController?.Dispose();
                _rewardedAdsMenuController?.Dispose();
                _analyticsManager.SendGameStartedEvent();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                _buyProductMenuController?.Dispose();
                _rewardedAdsMenuController?.Dispose();
                break;
        }
    }
}
