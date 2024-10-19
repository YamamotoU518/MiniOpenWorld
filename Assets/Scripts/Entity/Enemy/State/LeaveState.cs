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
        
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
