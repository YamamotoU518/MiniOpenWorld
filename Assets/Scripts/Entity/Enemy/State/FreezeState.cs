using UnityEngine;

/// <summary> 硬直ステート </summary>
public class FreezeState : IState
{
    private readonly EnemyBase _enemyBase = default;

    public FreezeState(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
    }

    public void Enter()
    {
        Debug.Log("止まります");
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        Debug.Log("動きます");
    }
}
