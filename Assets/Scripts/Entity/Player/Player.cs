using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private SelectData _selectData;
    private int _hp;
    
    private void Start()
    {
        _inventory.Add(1);
        _inventory.Add(2);
        _selectData._weaponId = 0;
    }

    private void Update()
    {
        
    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }
}
