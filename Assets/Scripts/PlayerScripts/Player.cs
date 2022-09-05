using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IWrapable
{
    public static Player singleton { get; private set; }

    private Mouse _mouse;
    private Camera _cam;

    [Header("Movement&Rotation")]
    [HideInInspector] public PlayerMovement playerMovement = new PlayerMovement();
    [HideInInspector] public RotationSystem rotationSystem = new RotationSystem();
    [HideInInspector] public MyPhysics myPhysics = new MyPhysics();
    [SerializeField] private float _rotationSpeed;
    public float MovementSpeed, TimeBeforeMaxSpeed, TimeBeforeStop;


    [Header("Weapons")]
    [SerializeField] private float _timeBetweenBulletShots;
    [SerializeField] private float _timeBetweenLaser;
    [SerializeField] private int _amountOfBullets;
    public int LaserReloadTime;
    private Weapon _weapon = new Weapon();
    private BulletGun _bulletGun;
    [HideInInspector] public LaserGun LaserGun;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _endOfGun;
    [SerializeField] private LineRenderer _laserBeam;

    [Header("")]
    [SerializeField] private Canvas _gameOverCanvas, _statisticsCanvas;



    public void Awake()
    {
        singleton = this;

        _mouse = Mouse.current;
        _cam = Camera.main;

        ///Add player to wrap screen 
        WrapScreen.singleton._wrapableObjects.Add(this);

        ///Creating guns and pools
        CreateGuns();
    }



    public void Update()
    {
        RotatePlayer();
        MoveObject();
    }



    public void OnTriggerEnter(Collider other) => PlayerTrigger.CheckObstacle(other.gameObject, this, _statisticsCanvas, _gameOverCanvas);



    private void CreateGuns()
    {
        LaserGun = new LaserGun(_endOfGun.transform, _timeBetweenLaser, VariableExtensions.SecondsToMilliseconds(LaserReloadTime), _laserBeam, _mouse, _cam);
        _bulletGun = new BulletGun(_endOfGun.transform, _timeBetweenBulletShots);

        /// Create bullet objects
        var createdBullets = _bulletGun._bulletPool.CreatePool(_amountOfBullets, _bulletPrefab);

        _bulletGun._bulletPool._bullets = InstantiateExtension.InstantiateQueue(createdBullets);
    }



    public Vector3 wrapablePosition
    {      
        get { return transform.position; }
        set { transform.position = value; }
    }



    public void ShootBullet(InputAction.CallbackContext context)
    {
        if (context.started) _weapon.Shoot(_bulletGun); 
    }



    public void ShootLaser(InputAction.CallbackContext context)
    {
        if (context.started) _weapon.Shoot(LaserGun); 
    }



    public void AddPlayerForce(InputAction.CallbackContext context)
    {
        playerMovement.AddPlayerForce(context, transform, MovementSpeed, TimeBeforeMaxSpeed, TimeBeforeStop, myPhysics);
    }



    private void RotatePlayer()
    {
        transform.rotation = rotationSystem.GetPlayerRotation(_mouse, transform.position, _cam);
    }



    private void MoveObject()
    {
        transform.position += myPhysics.MoveObject();
    }
}