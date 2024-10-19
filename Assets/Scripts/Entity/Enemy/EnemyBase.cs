using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private string _currentStateName;
    [SerializeField] private string _beforeStateName;
    protected IState _currentState = default;
    protected IdleState _idleState = default;
    public bool _isFreeze = false;
    
    private void Start()
    {
        _idleState = new IdleState(this);
        ChangeState(_idleState);
        OnStart();
    }

    protected virtual void OnStart() { }

    private void Update()
    {
        _currentState.Execute();
        OnUpdate();
    }
    
    protected virtual void OnUpdate() { }

    public void ChangeState(IState newState)
    {
        if (_currentState != null) { _currentState.Exit(); }

        _currentState = newState;
        _currentStateName = _currentState.GetType().Name;
        _currentState.Enter();
    }
}
