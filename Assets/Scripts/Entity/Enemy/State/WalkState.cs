using UnityEngine;
using UnityEngine.AI;

/// <summary> ランダム巡回ステート </summary>
public class WalkState : IState
{
    private readonly EnemyBase _enemyBase;
    private readonly NavMeshAgent _navMeshAgent;
    private readonly FreezeState _freezeState;
    private readonly Vector3 _pos; // 生成された場所
    private readonly float _distance = 1f; // ついたとみなす距離
    private readonly float _wanderRadius = 20f; // 徘徊する範囲の半径

    public WalkState(EnemyBase enemyBase, NavMeshAgent navMeshAgent,  FreezeState freezeState, Vector3 pos)
    {
        _enemyBase = enemyBase;
        _navMeshAgent = navMeshAgent;
        _freezeState = freezeState;
        _pos = pos;
    }
    
    public void Enter()
    {
        RandomNavPos(_pos, _wanderRadius, 1);
        _navMeshAgent.isStopped = false;
    }

    public void Execute()
    {
        Walk();
    }

    public void Exit()
    {
        _navMeshAgent.isStopped = true;
    }

    private void Walk()
    {
        if (_navMeshAgent.remainingDistance <= _distance) { _enemyBase.ChangeState(_freezeState);}
    }
    
    /// <summary> 次に向かう場所を決める </summary>
    /// <param name="origin"> 生成された場所 </param>
    /// <param name="dist"> 範囲 </param>
    /// <param name="layermask"> レイヤー </param>
    private void RandomNavPos(Vector3 origin, float dist, int layermask)
    {
        Vector3 rndDirection = Random.insideUnitSphere * dist;
        rndDirection += origin;

        NavMesh.SamplePosition(rndDirection, out var navHit, dist, layermask);
        
        _navMeshAgent.destination = navHit.position;
    }
}
