using UnityEngine;
using System.Collections.Generic;

public class Asteroid : MonoBehaviour,  IWrapable, IObstacle
{
    private MyPhysics myPhysics = new MyPhysics();
    private RotationSystem rotationSystem = new RotationSystem();
    private ObstacleFactory _myFactory = new ObstacleFactory();

    public List<AsteroidPiece> _pieces = new List<AsteroidPiece>();



    private void OnEnable()
    {
        /// Random rotate by z axis
        rotationSystem.RandomPosition(gameObject);
        rotationSystem.RandomRotation(gameObject);

        /// Add force to asteroid
        myPhysics.AddObjectForce(1, 3, transform.right);
    }



    private void OnDisable()
    {
        /// Create asteroid parts after destruction of this asteroid
         _myFactory.SpawnAsteroidPieces(_pieces, this);
    }



    private void Start()
    {
        WrapScreen.singleton._wrapableObjects.Add(this);
    }



    private void Update()
    {
        transform.position += myPhysics.MoveObject();
    }



    public void SpawnThis()
    {
        if(this != null) gameObject.SetActive(true);
    }



    public ObstacleFactory MyFactory
    {
        get { return _myFactory; }
        set { _myFactory = value; }
    }



    public GameObject thisGameObject
    {
        get { return gameObject; }
    }



    public Vector3 wrapablePosition
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
}
