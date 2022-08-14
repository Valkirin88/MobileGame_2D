using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    
    [Header("Scene Objects")]
    [SerializeField] private Transform _placeForUi;

    [SerializeField] private EntryPointConfig _config;

    private MainController _mainController;


    private void Start()
    {
        
        var profilePlayer = new ProfilePlayer(_config.SpeedCar, _config.InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
