using UnityEngine;
using UnityEngine.AI;

/// <summary> 追走ステート </summary>
public class ChaseState : IState
{
    private readonly EnemyBase _enemyBase = default;
    private NavMeshAgent _navMeshAgent = default;
    private readonly FreezeState _freezeState = default;
    private Vector3 _destination = default; // 目的地
    private Transform _playerTransform = default;

    public ChaseState(EnemyBase enemyBase, NavMeshAgent navMeshAgent, FreezeState freezeState)
    {
        _enemyBase = enemyBase;
        _navMeshAgent = navMeshAgent;
        _freezeState = freezeState;
    }

    public void Enter()
    {
        _navMeshAgent.isStopped = false;
    }

    public void Execute()
    {
        if (_playerTransform == null) { _enemyBase.ChangeState(_freezeState); }
        else
        {
            _destination = _playerTransform.position;
            _navMeshAgent.SetDestination(_destination);
        }
        var dir = (_destination - _navMeshAgent.transform.position).normalized;
        dir.y = 0;
        Quaternion setRotation = Quaternion.LookRotation(dir);
        _navMeshAgent.transform.rotation =
            Quaternion.Slerp(_navMeshAgent.transform.rotation, setRotation, _navMeshAgent.angularSpeed * 0.1f);

    }

    public void Exit()
    {
        _navMeshAgent.isStopped = true;
    }

    public void SetTransform(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }
}
