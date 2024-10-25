using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

/// <summary> 戦闘ステート </summary>
public class AttackState : IState
{
    private readonly EnemyBase _enemyBase;
    private readonly NavMeshAgent _navMeshAgent;
    private readonly FreezeState _freezeState;
    private readonly PlayableDirector _playableDirector;
    private bool _isAttack;
    private int _attackCount; // 攻撃回数
    private int _tactic = 1; // 体力によって確立に変化を持たせるためのパラメータ
    private Transform _playerTransform;
    private bool _canContinue;

    public AttackState(EnemyBase enemyBase,NavMeshAgent  navMeshAgent,FreezeState freezeState, PlayableDirector director)
    {
        _enemyBase = enemyBase;
        _navMeshAgent = navMeshAgent;
        _freezeState = freezeState;
        _playableDirector = director;
    }
    
    public void Enter()
    {
        Debug.Log("攻撃開始");
        _attackCount = 1;
        _canContinue = true;
    }

    public async void Execute()
    {
        if (_canContinue) await Attack();
    }

    public void Exit()
    {
        _playableDirector.time = _playableDirector.duration;
        Debug.Log("攻撃終了");
    }
    
    private static bool Probability(float percent)
    {
        float probabilityRate = Random.value * 100.0f;
    
        if (percent == 100.0f && probabilityRate == percent) return true;
        return probabilityRate < percent;
    }
    
    private async Task Attack()
    {
        if (_isAttack) return;
        _isAttack = true;
        _canContinue = false;
        _navMeshAgent.isStopped = true;

        var dis = (_navMeshAgent.transform.position - _playerTransform.position).sqrMagnitude;
        if (dis <= 5f)
        {
            _playableDirector.time = 0;
            _playableDirector.Stop();
            _playableDirector.Play();
                
            while (_playableDirector.time < _playableDirector.duration - 0.01f)
            {
                await Task.Yield();
            }
        }
        else if (dis <= 10f)
        {
            Debug.Log("中距離");
            _playableDirector.time = 0;
            _playableDirector.Stop();
            _playableDirector.Play();
                
            while (_playableDirector.time < _playableDirector.duration - 0.01f)
            {
                await Task.Yield();
            }
        }
        else
        {
            Debug.Log("遠距離");
            _playableDirector.time = 0;
            _playableDirector.Stop();
            _playableDirector.Play();
                
            while (_playableDirector.time < _playableDirector.duration - 0.01f)
            {
                await Task.Yield();
            }
        }
        
        AttackStop();
    }
    
    private void AttackStop()
    {
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
            _canContinue = true;
            _attackCount++;
        }
    }
    
    public void SetTransform(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void SetTactic(int value)
    {
        _tactic = value;
    }
}
