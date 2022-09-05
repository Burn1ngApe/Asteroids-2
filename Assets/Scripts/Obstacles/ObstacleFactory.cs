using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ObstacleFactory : MonoBehaviour
{
    private ObstaclePool _obstaclePool = new ObstaclePool();
    [SerializeField] private PrefabAmount[] prefabs;



    private void Start()
    {
        _obstaclePool.CreateObstacles(prefabs);

        SpawnObstacles();
    }



    private void SpawnObstacles()
    {
        _obstaclePool._spawnedObstacles = InstantiateExtension.InstantiateList(_obstaclePool._spawnedObstacles);
    }



    public async void Respawn(IObstacle obstacle)
    {
        await Task.Delay(1000);

        obstacle.SpawnThis();
    }



    public async void SpawnAsteroidPieces(List<AsteroidPiece> pieces, Asteroid parentAsteroid)
    {
        /// Wait after deactivating parent asteroid to enable pieces
        await Task.Delay(100);

        foreach (var piece in pieces)
        {
            if (piece == null) return;

            piece.gameObject.transform.parent = null;
            piece.gameObject.transform.position = parentAsteroid.transform.position;
            piece.MyFactory = this;
            piece.ParentAsteroid = parentAsteroid;
            piece.gameObject.SetActive(true);
        }
    }
}



public interface IObstacle
{
    public GameObject thisGameObject { get; }
    public void SpawnThis();
    public ObstacleFactory MyFactory { get; set; }
}

