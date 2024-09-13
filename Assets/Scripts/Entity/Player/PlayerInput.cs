using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IPlayerInput[] _iPlayerInput = default;
    
    private void Start()
    {
        _iPlayerInput = GetComponents<IPlayerInput>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            foreach (var item in _iPlayerInput)
            {
                item.InputRight();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            foreach (var item in _iPlayerInput)
            {
                item.InputLeft();
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            foreach (var item in _iPlayerInput)
            {
                item.InputForward();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            foreach (var item in _iPlayerInput)
            {
                item.InputBack();
            }
        }
    }
}
