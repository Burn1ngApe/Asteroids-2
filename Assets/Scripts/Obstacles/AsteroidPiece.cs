using UnityEngine;

public class AsteroidPiece : MonoBehaviour, IWrapable, IObstacle
{
    [HideInInspector] public Asteroid ParentAsteroid;
    public AsteroidPiece TwinPiece;

    private ObstacleFactory _myFactory = new ObstacleFactory();
    private MyPhysics myPhysics = new MyPhysics();
    private RotationSystem rotationSystem = new RotationSystem();



    private void OnEnable()
    {
        /// Random rotate by z axis
        rotationSystem.RandomRotation(gameObject);

        /// Add force to asteroid
        myPhysics.AddObjectForce(1, 3, transform.right);
    }



    private void OnDisable()
    {
        if (TwinPiece != null && TwinPiece.isActiveAndEnabled) _myFactory.Respawn(ParentAsteroid);
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
        if (this != null) gameObject.SetActive(true);
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
