using System.Collections.Generic;
using UnityEngine;

public class InstantiateExtension
{
    public static List<GameObject> InstantiateList(List<GameObject> createdObjects)
    {
        var instantiatedObjects = new List<GameObject>();


        foreach (var obj in createdObjects)
        {
            instantiatedObjects.Add(GameObject.Instantiate(obj));
        }

        /// Replace objects to create with instantiated objectss
        createdObjects = instantiatedObjects;

        return createdObjects;
    }



    public static Queue<GameObject> InstantiateQueue(Queue<GameObject> createdObjects)
    {
        var instantiatedBullets = new Queue<GameObject>();

        foreach (var bullet in createdObjects) instantiatedBullets.Enqueue(GameObject.Instantiate(bullet));

        /// Replace bullets in the pool with already instantiated bullets
        createdObjects = instantiatedBullets;

        return createdObjects;
    }
}
