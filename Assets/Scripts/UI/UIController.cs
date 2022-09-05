using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private UIDataService _uiDataService;
    private Player _playerController;

    [SerializeField] private TMP_Text _speed, _angle, _coordinates, _lasetAmount, _laserReloadTime;



    private void Start()
    {
        _playerController = Player.singleton;
        _uiDataService = new UIDataService(_playerController);
    }



    private void Update()
    {
        /// Show speed
        _speed.text = _uiDataService.GetSpeed();

        /// Show angle of player rotation
        _angle.text = _uiDataService.GetAngle();

        /// Show player coordinates
        _coordinates.text = _uiDataService.GetCoordinates();

        /// Show amount of laset beams avaliable
        _lasetAmount.text = _uiDataService.GetLaserAmount();

        /// Show time it takes for laser to reload
        _laserReloadTime.text = _uiDataService.GetLaserReloadTime();
    }



    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
