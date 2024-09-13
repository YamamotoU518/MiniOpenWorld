using UnityEngine;

public enum EnemyActionState
{
    Alert,
    Freeze, // 硬直
    CloseRangeAttack, // 近距離攻撃
    MediumRangeAttack, // 中距離攻撃
    LongRangeAttack // 遠距離攻撃
}

/// <summary> Chase状態のときにどんなことをするかを制御するクラス </summary>
public class EnemyActionContoller : MonoBehaviour
{
    [SerializeField] private EnemyActionState _currentActionState;
    private EnemyController _enemyController = default;
    private void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (EnemyState.Chase != _enemyController.GetState()) return;
    }
}
