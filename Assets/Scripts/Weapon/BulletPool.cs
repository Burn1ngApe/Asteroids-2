using System.Collections.Generic;
using UnityEngine;

public class BulletPool 
{
    public Queue<GameObject> _bullets = new Queue<GameObject>();



    public Queue<GameObject> CreatePool(int capacity, GameObject prefab)
    {
        for(int i =0; i< capacity; i++)
        {
            GameObject newBullet;
            newBullet = prefab;
            newBullet.SetActive(false);
            _bullets.Enqueue(newBullet);
        }

        return _bullets;
    }



    public GameObject GetBullet(Vector3 direction)
    {
        var firstBullet = _bullets.Dequeue();
        _bullets.Enqueue(firstBullet);
        return firstBullet;
    }
}
