using UnityEngine;
using UnityEngine.AI;

/// <summary> Enemyの状態を制御するクラス </summary>
public class EnemyController : EnemyBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particle;
    private NavMeshAgent _navMeshAgent = default;
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
        _attackState = new AttackState(this, _navMeshAgent, _freezeState, _particle);
        
        ChangeState(_walkState);
    }
    protected override void OnUpdate()
    {
        if (_currentState == _chaseState) { _chaseState.SetTransform(_targetTransform); }
        if (_currentState == _attackState) { _attackState.SetTransform(_targetTransform); }
    }
    
    /// <summary> プレイヤーの位置によってstateを切り替える </summary>
    /// <param name="playerTransform"> プレイヤーの位置 </param>
    /// <param name="inViewAngle"> 視野角内か </param>
    public void ChangeStateByPlayerPos(Transform playerTransform, bool inViewAngle)
    {
        if (inViewAngle == false) // 視野角外ならidleStateに移行
        {
            _currentState = _idleState;
            return;
        }
        
        _targetTransform = playerTransform;
        var dis = (gameObject.transform.position - _targetTransform.position).sqrMagnitude;
        
        if (dis < 10f)
        {
            if (_currentState == _attackState) return;
            ChangeState(_attackState);
            _attackState.SetTransform(_targetTransform);
            _attackState.SetTactic(1);
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
