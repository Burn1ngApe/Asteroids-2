using UnityEngine;
using System.Collections.Generic;

public class WrapScreen : MonoBehaviour
{
    public static WrapScreen singleton;


    private Vector3 _rightSide = new Vector3();
    private Vector3 _upperSide = new Vector3();

    [SerializeField] private float _offset;

    public List<IWrapable> _wrapableObjects = new List<IWrapable>();


    private void Awake() 
    {
        singleton = this;
        CreateWarpSpace();
    }



    public void Update()
    {
        CheckObjectPosition();
    }



    private void CreateWarpSpace()
    {
        Camera cam = Camera.main;

        _rightSide = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        _upperSide = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        _rightSide.x += _offset; _upperSide.y += _offset;
    }



    public void CheckObjectPosition()
    {
        foreach (IWrapable wrapable in _wrapableObjects)
        {
            var objPosition = wrapable.wrapablePosition;

            var reversedPosition = objPosition;

            if (objPosition.x > _rightSide.x || objPosition.x < -_rightSide.x) reversedPosition = -objPosition;
            else if (objPosition.y > _upperSide.y || objPosition.y < -_upperSide.y) reversedPosition = -objPosition;

            wrapable.wrapablePosition = reversedPosition;
        }
    }
}



public interface IWrapable
{
    public Vector3 wrapablePosition { get; set; }
}
