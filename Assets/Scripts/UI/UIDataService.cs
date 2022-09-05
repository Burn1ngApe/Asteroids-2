using UnityEngine;
using System.Text;

public class UIDataService 
{
    private Player _player;
    private StringBuilder _coordinatesString = new StringBuilder();

    

    public UIDataService(Player playerController)
    {
        _player = playerController;
    }



    public string GetSpeed()
    {
        return _player.myPhysics.CurrentSpeed.ToString("F2");
    }



    public string GetAngle()
    {
        return _player.rotationSystem.CurrentAngle.ToString("F2");
    }



    public string GetCoordinates()
    {
        _coordinatesString.Clear();
        _coordinatesString.Append($" X: {_player.transform.position.x.ToString("F1")}" + $" Y: {_player.transform.position.y.ToString("F1")}");

        return _coordinatesString.ToString();
    }



    public string GetLaserAmount()
    {
        return _player.LaserGun.AmmoAmount.ToString();
    }



    public string GetLaserReloadTime()
    {
        return _player.LaserReloadTime.ToString() + " sc.";
    }
}
