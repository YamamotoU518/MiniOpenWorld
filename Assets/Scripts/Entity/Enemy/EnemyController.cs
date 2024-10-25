using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using Cysharp.Threading.Tasks;

/// <summary> Enemyの状態を制御するクラス </summary>
public class EnemyController : EnemyBase
{
    [SerializeField] private Hp _hp;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField, Header("Freezeのときにどのくらい止まるか")] private int _freezeTime;
    private NavMeshAgent _navMeshAgent;
    private Transform _targetTransform;
    private WalkState _walkState;
    private ChaseState _chaseState;
    private LeaveState _leaveState;
    private FreezeState _freezeState;
    private AttackState _attackState;
    
    protected override void OnStart()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        var token = this.GetCancellationTokenOnDestroy();

        _freezeState = new FreezeState(this, _freezeTime, token);
        _chaseState = new ChaseState(this, _navMeshAgent, _freezeState);
        _walkState = new WalkState(this, _navMeshAgent, _freezeState, gameObject.transform.position);
        _leaveState = new LeaveState(this);
        _attackState = new AttackState(this, _navMeshAgent, _freezeState, _playableDirector);

        ChangeState(_walkState);
    }
    
    protected override void OnUpdate()
    {
        if (_currentState == _freezeState && !_isFreeze) ChangeState(_walkState);
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
        
        if (dis < 15f)
        {
            if (_currentState == _attackState || _isFreeze) return;
            ChangeState(_attackState);
            _attackState.SetTransform(_targetTransform);
            _attackState.SetTactic((int)(4 - 3 * _hp.CurrentHp / _hp.MaxHp));
        }
        else if (dis < 20f)
        {
            if (_currentState == _chaseState) return;
            ChangeState(_chaseState);
            _chaseState.SetTransform(_targetTransform);
        }
        else
        {
            if (_currentState == _walkState) return;
            ChangeState(_walkState);
        }
    }
}
