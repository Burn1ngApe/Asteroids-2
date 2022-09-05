using UnityEngine;
public class BulletTrigger
{
    public static void CheckBullet(BulletBehaviour bullet, GameObject obstacle)
    {
        if (obstacle.CompareTag("Obstacle"))
        {
            obstacle.SetActive(false);

            bullet.StopBullet();
        }
    }
}
