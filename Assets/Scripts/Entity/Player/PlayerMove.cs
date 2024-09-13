using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IPlayerInput
{
    [SerializeField] private float _speed = default;
    public void InputRight()
    {
        var pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x + _speed, pos.y, pos.z);
    }

    public void InputLeft()
    {
        var pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x - _speed, pos.y, pos.z);
    }

    public void InputForward()
    {
        var pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + _speed);
    }

    public void InputBack()
    {
        var pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - _speed);    
    }
}
