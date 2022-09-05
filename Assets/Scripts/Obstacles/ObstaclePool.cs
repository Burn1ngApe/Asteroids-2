using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool
{
    public List<GameObject> _spawnedObstacles = new List<GameObject>();


    public void CreateObstacles(PrefabAmount[] prefabs)
    {
        for(int prefabType =0; prefabType < prefabs.Length; prefabType++)
        {
            for(int amountToCreate = 0; amountToCreate < prefabs[prefabType].Amount; amountToCreate++)
            {
                GameObject newObject;
                newObject = prefabs[prefabType].Prefab;

                _spawnedObstacles.Add(newObject);
            }
        }
    }


}
