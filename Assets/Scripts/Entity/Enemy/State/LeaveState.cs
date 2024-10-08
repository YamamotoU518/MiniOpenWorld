/// <summary> 逃走ステート </summary>
public class LeaveState : IState
{
    private EnemyBase _enemyBase = default;

    public LeaveState(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
    }
    
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
