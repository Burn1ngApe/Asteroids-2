using UnityEngine;

public class BulletGun : IWeapon
{
    private Transform _startTransform;
    private float  _timeBetweenShots;

    public BulletPool _bulletPool;

    private float _generalTime = 0;



    public BulletGun(Transform startTransform,  float timeBetweenShot)
    {
        _startTransform = startTransform;
        _timeBetweenShots = timeBetweenShot;

        _bulletPool = new BulletPool();
    }



    public void Shoot()
    {
        if (Time.time > _generalTime)
        {
            _generalTime = Time.time + _timeBetweenShots;

            var bullet = _bulletPool.GetBullet(_startTransform.up);

            bullet.GetComponent<BulletBehaviour>().StopBullet();

            bullet.transform.position = _startTransform.position;
            bullet.transform.right = _startTransform.transform.up;
            bullet.SetActive(true);
        }
    }
}
