using UnityEngine;

/// <summary> 待機ステート </summary>
public class IdleState : IState
{
    private readonly EnemyBase _enemyBase;
    
    public IdleState(EnemyBase enemyBase) { _enemyBase = enemyBase; }
    
    public void Enter() { }

    public void Execute() { }

    public void Exit() { }
}
