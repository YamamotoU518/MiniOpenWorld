using UnityEngine;

/// <summary> 戦闘ステート </summary>
public class AttackState : IState
{
    private EnemyBase _enemyBase = default;
    private bool _isAttack = default;
    private int _attackCount = 0; // 攻撃回数
    private int _tactic = 1; // 体力の判定用

    public AttackState(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
    }
    
    public void Enter()
    {
        Debug.Log("攻撃開始");
    }

    public void Execute()
    {
        
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
    
    private void AttackStop()
    {
        Debug.Log("攻撃終了");
        _isAttack = false;
        //if (_currentState == EnemyState.Freeze) SetState(EnemyState.Chase);
        // 上があったらelse
        {
            Debug.LogError("a");
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
                // SetState(EnemyState.Freeze);
                _attackCount = 1;
            }
            else // 継続
            {
                // SetState(EnemyState.Chase, _targetTransform);
                _attackCount++;
            }
        }
    }
    
    // private void Attack()
    // {
    //     if (_isAttack) return; 
    //     _isAttack = true;
    //     _navMeshAgent.isStopped = true;
    //     StartCoroutine(PerformAttack());
    // }
    //
    // private IEnumerator PerformAttack()
    // {
    //     var dis = Vector3.Distance(transform.position, _targetTransform.position);
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
}
