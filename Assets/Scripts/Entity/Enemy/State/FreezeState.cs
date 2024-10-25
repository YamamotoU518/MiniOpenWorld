using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary> 硬直ステート </summary>
public class FreezeState : IState
{
    private readonly EnemyBase _enemyBase;
    private readonly float _freezeTime;
    private readonly CancellationToken _token;

    public FreezeState(EnemyBase enemyBase, float freezeTime, CancellationToken token)
    {
        _enemyBase = enemyBase;
        _freezeTime = freezeTime;
        _token = token;
    }

    public void Enter()
    {
        _enemyBase._isFreeze = true;
        StartFreezeTimer().Forget();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        _enemyBase._isFreeze = false;
    }

    private async UniTask StartFreezeTimer()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_freezeTime), cancellationToken:_token);
        _enemyBase._isFreeze = false;
    }
}
