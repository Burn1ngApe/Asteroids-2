using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{

    public Vector3 DetermineDirectionToMove(InputAction.CallbackContext context, Transform transform)
    {
        Vector3 directionForce = new Vector3();

        var directionOfInput = context.ReadValue<Vector2>();

        /// If x of DirectionInput equals 1 it means right direction
        /// If x equals -1 it means left direction
        /// If y equals 1 it means forward direction
        /// Else direction equals zero
        if (directionOfInput.x == 1) { directionForce = transform.up; }
        else if (directionOfInput.x == -1) { directionForce = -transform.up; }
        else if (directionOfInput.y == 1) { directionForce = -transform.right; }
        else directionForce = Vector3.zero;
        
        return directionForce;
    }



    public void AddPlayerForce(InputAction.CallbackContext context, Transform transform, float movementSpeed, float timeBeforeMaxSpeed, float timeBeforeStop, MyPhysics myPhysics)
    {      
        /// Add force to player on press button
        if (context.started)
        {
            /// Getting direction of the force before adding it to player
            var directionForce = DetermineDirectionToMove(context, transform);

            /// If direction force is zero than dont add force to the object
            if (directionForce == Vector3.zero) return;

            myPhysics.AddObjectForce(movementSpeed, timeBeforeMaxSpeed, directionForce);
        }
        /// Stop the player on release button
        else if (context.canceled)
        {
            myPhysics.StopObject(timeBeforeStop);
        }
    }
}
