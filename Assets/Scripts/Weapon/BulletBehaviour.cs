using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private MyPhysics _myPhysics = new MyPhysics();



    public void OnEnable()
    {
        _myPhysics.AddObjectForce(10, 0.1f, transform.right);
    }



    public void Update()
    {
        MoveBullet();
    }



    public void OnTriggerEnter(Collider other) => BulletTrigger.CheckBullet(this, other.gameObject); 



    private void MoveBullet()
    {
        transform.position += _myPhysics.MoveObject();
    }



    public void StopBullet()
    {
        _myPhysics.StopObject(0f);
        gameObject.SetActive(false);
    }
}
