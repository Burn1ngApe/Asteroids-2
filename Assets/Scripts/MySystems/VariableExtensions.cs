using UnityEngine;

public class VariableExtensions
{
    public static Vector2 Vector3To2(Vector3 vector)
    {
        Vector2 newVector2 = new Vector2(vector.x, vector.y);
        return newVector2;
    }



    public static int SecondsToMilliseconds(int seconds)
    {
        return seconds * 1000;
    }
}
