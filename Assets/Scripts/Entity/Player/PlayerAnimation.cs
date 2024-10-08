using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerInput
{
    [SerializeField] private Animator _animator;
    [SerializeField] private WeaponDataStore _weaponDataStore;
    [SerializeField] private SelectData _selectData;
    
    public void InputRight()
    {
        _animator.SetBool("Run", true);
    }

    public void InputLeft()
    {
        _animator.SetBool("Run", true);
    }

    public void InputForward()
    {
        _animator.SetBool("Run", true);
    }

    public void InputBack()
    {
        _animator.SetBool("Run", true);
    }

    public void Release()
    {
        _animator.SetBool("Run", false);
    }

    public void Attack()
    {
        if (_selectData._weaponId == 0)
        {
            _animator.SetBool("Punch", true);
            StartCoroutine(ResetAttack("Punch"));
            return;
        }
        switch (_selectData._weaponId)
        {
            case 1:
                _animator.SetBool("Attack", true);
                break;
            case 2:
                _animator.SetBool("BowAttack", true);
                StartCoroutine(ResetAttack("BowAttack"));
                break;
        }
    }
    
    private IEnumerator ResetAttack(string name)
    {
        yield return new WaitForSeconds(1.0f);  // アニメーションが終わるまでの待ち時間を設定
        _animator.SetBool(name, false);
    }
}
