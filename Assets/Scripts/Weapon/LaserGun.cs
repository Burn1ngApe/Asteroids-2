using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class LaserGun : IWeapon
{
    private float _generalTime = 0, _timeBetweenShots;
    private Transform _startTransform;
    private LineRenderer _laserBeam;

    private Mouse _mouse;
    private Camera _cam;

    public int AmmoAmount = 5;
    private int _reloadTime;



    public LaserGun(Transform startTransform, float timeBetweenShot, int reloadTime, LineRenderer laserBeam, Mouse mouse, Camera cam)
    {
        _startTransform = startTransform;
        _timeBetweenShots = timeBetweenShot;
        _laserBeam = laserBeam;
        _reloadTime = reloadTime;

        _mouse = mouse;
        _cam = cam;
    }



    public void Shoot()
    {
        if (AmmoAmount > 0 && Time.time > _generalTime)
        {
            _generalTime = Time.time + _timeBetweenShots;

            /// Decrease ammount of ammo
            AmmoAmount--;

            /// Mouse position in the world
            Vector2 mousePosition = _cam.ScreenToWorldPoint(_mouse.position.ReadValue());

            /// Drawing laset beam as line renderer
            CreateLaserBeam(mousePosition);

            ///Detecting and deactivating objetcs hit by laset
            DetectObjects(mousePosition);

            ///Start increasing ammount of ammo with time
            ReloadLaserAmmo();
        }
    }



    private async void CreateLaserBeam(Vector2 mousePosition)
    {
        _laserBeam.enabled = true;

        _laserBeam.SetPosition(0, _startTransform.position); _laserBeam.SetPosition(1, mousePosition);

        await Task.Delay(300);

        _laserBeam.enabled = false;
    }



    private void DetectObjects(Vector2 mousePosition)
    {
        var dir = VariableExtensions.Vector3To2(_startTransform.position) - mousePosition;

        RaycastHit[] hits;
        Ray ray = new Ray(_startTransform.position, -dir);

        hits = Physics.RaycastAll(ray, dir.magnitude);

        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }



    private async void ReloadLaserAmmo()
    {
        await Task.Delay(_reloadTime);
        AmmoAmount++;
    }
}
