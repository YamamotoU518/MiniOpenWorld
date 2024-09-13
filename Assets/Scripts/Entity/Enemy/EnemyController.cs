using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle, // なにもしていない
    Walk, // 巡回中
    Chase, // 戦闘中
    Leave // 逃走中
}

/// <summary> Enemyの状態を制御するクラス </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState _currentState;
    [SerializeField] private Quaternion _setRotation;
    [SerializeField] private GameObject _WanderingArea; // 巡回するエリア
    private Transform _targetTransform = default;
    private NavMeshAgent _navMeshAgent = default;
    private Vector3 _destinationPos = default;
    private float _timer = default; // 巡回中に次の行き先が決められる時間用
    private float _wanderRadius = 10f; // 徘徊する範囲の半径
    
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_currentState == EnemyState.Chase)
        {
            if (_targetTransform == null)
            {
                SetState(EnemyState.Idle);
            }
            else
            {
                _destinationPos = _targetTransform.position;
                _navMeshAgent.SetDestination(_destinationPos);
            }

            var dir = (_destinationPos - transform.position).normalized;
            dir.y = 0;
            Quaternion setRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, setRotation, _navMeshAgent.angularSpeed * 0.1f);
        }
        else if (_currentState == EnemyState.Walk)
        {
            _timer += Time.deltaTime;
            if (_timer >= 5f)
            {
                Vector3 rmd = RandomNavPos(transform.position, _wanderRadius, 1);
                
            }
        }
        else if (_currentState == EnemyState.Leave)
        {
            
        }
    }

    public void SetState(EnemyState state, Transform target = null)
    {
        //Debug.Log($"現在のステートは{_currentState}");
        _currentState = state;
        if (_currentState == EnemyState.Idle)
        {
            _navMeshAgent.isStopped = true;
        }
        else if (_currentState == EnemyState.Chase)
        {
            _targetTransform = target;
            _navMeshAgent.isStopped = false;
        }
    }

    public EnemyState GetState()
    {
        return _currentState;
    }

    private static Vector3 RandomNavPos(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMesh.SamplePosition(randDirection, out var navHit, dist, layermask);

        return navHit.position;
    }
}
