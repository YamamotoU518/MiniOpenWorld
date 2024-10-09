using UnityEngine;
using UnityEngine.AI;

/// <summary> 戦闘ステート </summary>
public class AttackState : IState
{
    private EnemyBase _enemyBase = default;
    private NavMeshAgent _navMeshAgent = default;
    private FreezeState _freezeState = default;
    private Animator _animator = default;
    private ParticleSystem _particle = default;
    private bool _isAttack = default;
    private int _attackCount = 0; // 攻撃回数
    private int _tactic = 1; // 体力によって確立に変化を持たせるためのパラメータ
    private Transform _playerTransform = default;

    public AttackState(EnemyBase enemyBase,NavMeshAgent  navMeshAgent,FreezeState freezeState, ParticleSystem particle)
    {
        _enemyBase = enemyBase;
        _navMeshAgent = navMeshAgent;
        _freezeState = freezeState;
        //_animator = animator;
        _particle = particle;
    }
    
    public void Enter()
    {
        Debug.Log("攻撃開始");
        _attackCount = 1;
    }

    public void Execute()
    {
        Attack();
    }

    public void Exit()
    {
        Debug.Log("攻撃終了");
    }
    
    private static bool Probability(float percent)
    {
        float probabilityRate = Random.value * 100.0f;
    
        if (percent == 100.0f && probabilityRate == percent) return true;
        return probabilityRate < percent;
    }
    
    private void Attack()
    {
        if (_isAttack) return; 
        _isAttack = true;
        _navMeshAgent.isStopped = true;
        
        var dis = Vector3.Distance(_navMeshAgent.transform.position, _playerTransform.position);
        if (dis <= 5f)
        {
            Debug.Log("近距離");
            _particle.Play();
            // foreach (var action in _enemyActions)
            // {
            //     action.CloseRangeAttack();
            //     yield return new WaitUntil(() => action.IsAttackFinished);
            // }
        }
        else if (dis <= 10f)
        {
            Debug.Log("中距離");
            // foreach (var action in _enemyActions)
            // {
            //     action.MediumRangeAttack();
            //     yield return new WaitUntil(() => action.IsAttackFinished);
            // }
        }
        else
        {
            Debug.Log("遠距離");
            // foreach (var action in _enemyActions)
            // {
            //     action.LongRangeAttack();
            //     yield return new WaitUntil(() => action.IsAttackFinished);
            // }
        }
        
        AttackStop();
    }
    
    private void AttackStop()
    {
        Debug.Log($"{_attackCount}回目の攻撃終了");
        _isAttack = false;
        
        float percent = 0f;
        switch (_tactic)
        {
            case 1:
                percent = 100.0f;
                break;
            case 2:
                if (_attackCount == 1) percent = 50.0f;
                else if (_attackCount == 2) percent = 100.0f;
                break;
            case 3:
                if (_attackCount == 1) percent = 30.0f;
                else if (_attackCount == 2) percent = 70.0f;
                else if (_attackCount == 3) percent = 100.0f;
                break;
        }

        if (Probability(percent)) // 攻撃終了
        {
            _enemyBase.ChangeState(_freezeState);
        }
        else // 継続
        {
            _attackCount++;
        }
    }
    
    // private IEnumerator PerformAttack()
    // {
    //     var dis = Vector3.Distance(_navMeshAgent.transform.position, _playerTransform.position);
    //     if (dis <= 5f)
    //     {
    //         Debug.Log("近距離");
    //         foreach (var action in _enemyActions)
    //         {
    //             action.CloseRangeAttack();
    //             yield return new WaitUntil(() => action.IsAttackFinished);
    //         }
    //     }
    //     else if (dis <= 10f)
    //     {
    //         Debug.Log("中距離");
    //         foreach (var action in _enemyActions)
    //         {
    //             action.MediumRangeAttack();
    //             yield return new WaitUntil(() => action.IsAttackFinished);
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log("遠距離");
    //         foreach (var action in _enemyActions)
    //         {
    //             action.LongRangeAttack();
    //             yield return new WaitUntil(() => action.IsAttackFinished);
    //         }
    //     }
    //     
    //     AttackStop();
    //     Debug.Log("stop");
    // }
    
    public void SetTransform(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void SetTactic(int value)
    {
        _tactic = value;
    }
}
