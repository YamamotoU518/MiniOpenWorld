using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animName;

    public void SetBoolFalse()
    {
        _animator.SetBool(_animName, false);
    }
}
