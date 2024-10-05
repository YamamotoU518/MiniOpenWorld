using UnityEngine;

/// <summary> 待機ステート </summary>
public class IdleState : IState
{
    private readonly EnemyBase _enemyBase = default;
    
    public IdleState(EnemyBase enemyBase) { _enemyBase = enemyBase; }
    
    public void Enter() { Debug.Log("現在のステートはidleです"); }

    public void Execute() { }

    public void Exit() { Debug.Log("idleステートが終わりました"); }
}
