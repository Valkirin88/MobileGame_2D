using Profile;
using Services.Ads.UnityAds;
using Tool.Analytics;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;
    [SerializeField] private AnalyticsManager _analyticsManager;
    [SerializeField] private UnityAdsService _adsService;

    private MainController _mainController;
    
 
    private void Start()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer, _analyticsManager, _adsService);

        if (_adsService.IsInitialized)
            OnAdsInitialized();
        else
            _adsService.Initialized.AddListener(OnAdsInitialized);
       
    }

    private void OnDestroy()
    {
        _adsService.Initialized.RemoveListener(OnAdsInitialized);
        _mainController.Dispose(); 
    }

    private void OnAdsInitialized() => _adsService.InterstitialPlayer.Play();
}
