using UnityEngine;

public class MyPhysics
{
    private AnimationCurve _animationCurve = new AnimationCurve();

    public float CurrentSpeed = 0;
    private float _currentTime = 0;

    private Vector3 _currentDirection = new Vector3();



    public void AddObjectForce(float movementSpeed, float timeBeforeMaxSpeed, Vector3 direction)
    {
        _currentDirection = direction;

        /// Reset previous curve
        _animationCurve = new AnimationCurve();
        _currentTime = 0;

        /// Create new curve
        _animationCurve.AddKey(0, CurrentSpeed);
        _animationCurve.AddKey(timeBeforeMaxSpeed, movementSpeed);
    }



    public void StopObject(float timeBeforeStop)
    {
        /// Reset previous curve
        _animationCurve = new AnimationCurve();
        _currentTime = 0;

        /// Create new curve
        _animationCurve.AddKey(0, CurrentSpeed);
        _animationCurve.AddKey(timeBeforeStop, 0);
    }



    public Vector3 MoveObject()
    {
        /// Copying direction of the force from previosly set variable
        var forceDirection = _currentDirection;

        /// Getting object force from animation curve
        float objectForce = _animationCurve.Evaluate(_currentTime);
        CurrentSpeed = objectForce;

        _currentTime += Time.deltaTime;

        /// Direction of the force is changing according to changing objectForce
        forceDirection *= objectForce * Time.deltaTime;

        return forceDirection;
    }


    
    public Vector3 FollowObject(Vector3 thisPosition, Vector3 objPosition, float speed)
    {
        var newPosition = Vector2.MoveTowards(thisPosition, objPosition, speed * Time.deltaTime);
        return newPosition;
    }

}
