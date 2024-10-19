using UnityEngine;

public class Hp : MonoBehaviour, IDamage
{
    [SerializeField] private float _maxHp;
    public float MaxHp => _maxHp;
    [SerializeField] private float _currentHp = default;
    public float CurrentHp => _currentHp;
    
    private void Start()
    {
        _currentHp = _maxHp;
    }

    private void Update()
    {
        
    }

    public void Damage(float value)
    {
        if (_currentHp <= 0) return;
        _currentHp -= value;
    }
}
