using UnityEngine;

public class UFO : MonoBehaviour, IWrapable, IObstacle
{
    private MyPhysics myPhysics = new MyPhysics();
    private RotationSystem rotationSystem = new RotationSystem();
    private Player _player;
    private ObstacleFactory _myFactory = new ObstacleFactory();



    private void OnEnable()
    {
        rotationSystem.RandomPosition(gameObject);
    }



    private void Start()
    {
        _player = Player.singleton;
        WrapScreen.singleton._wrapableObjects.Add(this);
    }



    private void OnDisable()
    {       
        _myFactory.Respawn(this);
    }



    private void Update()
    {
        transform.position = myPhysics.FollowObject(transform.position, _player.transform.position, 2);
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
