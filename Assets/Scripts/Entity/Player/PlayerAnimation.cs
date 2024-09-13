using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerInput
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.Play("PlayerIdle");
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", false);
    }

    public void InputRight()
    {
        _animator.SetBool("Walk", true);
    }

    public void InputLeft()
    {
        _animator.SetBool("Walk", true);
    }

    public void InputForward()
    {
        _animator.SetBool("Walk", true);
    }

    public void InputBack()
    {
        _animator.SetBool("Walk", true);
    }
}
