using UnityEngine;
using UnityEngine.InputSystem;

public class RotationSystem
{
    public float CurrentAngle = 0f;


    public Quaternion GetPlayerRotation(Mouse _mouse, Vector3 playerPosition, Camera cam)
    {
        /// Getting cursor position
        var _mousePosition = _mouse.position.ReadValue();

        Vector2 positionOnScreen = cam.WorldToViewportPoint(playerPosition);
        Vector2 mouseOnScreen = cam.ScreenToViewportPoint(_mousePosition);

        /// Calculating angle between player position and cursor position on viewport
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        CurrentAngle = angle;

        var newQuat = Quaternion.Euler(new Vector3(0f, 0f, angle));

        return newQuat;
    }



    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }



    public void RandomPosition(GameObject obj)
    {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width+ 5), Random.Range(Screen.height, Screen.height + 5), 0));
            screenPosition.z = 0;

            obj.transform.position = screenPosition;
    }



    public void RandomRotation(GameObject obj)
    {
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        obj.transform.rotation = randomRotation;
    }

}
