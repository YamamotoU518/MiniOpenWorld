using UnityEngine;
using UnityEngine.AI;

/// <summary> Enemyの状態を制御するクラス </summary>
public class EnemyController : EnemyBase
{
    private NavMeshAgent _navMeshAgent = default;
    private bool _isAttack = false;
    private int _attackCount = 0; // 攻撃回数
    private int tactic = 1; // 体力の判定用

    private Transform _targetTransform = default;
    private WalkState _walkState = default;
    private ChaseState _chaseState = default;
    private LeaveState _leaveState = default;
    private FreezeState _freezeState = default;
    private AttackState _attackState = default;
    
    protected override void OnStart()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _freezeState = new FreezeState(this);
        _chaseState = new ChaseState(this, _navMeshAgent, _freezeState);
        _walkState = new WalkState(this, _navMeshAgent, _freezeState, gameObject.transform.position);
        _leaveState = new LeaveState(this);
        _attackState = new AttackState(this);
        
        ChangeState(_walkState);
    }
    protected override void OnUpdate()
    {
        if (_currentState == _chaseState) { _chaseState.SetTransform(_targetTransform); }
    }
    
    /// <summary> プレイヤーの位置によってstateを切り替える </summary>
    /// <param name="playerTransform"> プレイヤーの位置 </param>
    /// <param name="inViewAngle"> 視野角内か </param>
    public void ChangeStateByPlayerPos(Transform playerTransform, bool inViewAngle = true)
    {
        _targetTransform = playerTransform;
        var dis = (gameObject.transform.position - _targetTransform.position).sqrMagnitude;
        
        if (inViewAngle == false) // 視野角外ならidleStateに移行
        {
            _currentState = _idleState;
            return;
        }
        
        if (dis < 10f)
        {
            if (_currentState == _attackState) return;
            ChangeState(_attackState);
        }
        else if (dis < 15f)
        {
            if (_currentState == _chaseState) return;
            ChangeState(_chaseState);
            _chaseState.SetTransform(_targetTransform);
        }
        else
        {
            if (_currentState == _walkState) return;
            ChangeState(_freezeState);
        }
    }
}
