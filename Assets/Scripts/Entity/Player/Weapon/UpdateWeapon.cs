using UnityEngine;

/// <summary> 装備してる武器の変更(キャラクターに装備) </summary>
public class UpdateWeapon : MonoBehaviour
{
    [SerializeField] private WeaponDataStore _weaponDataStore;
    [SerializeField] private SelectData _selectData;
    private GameObject _currentObj = default;

    public void Set()
    {
        Destroy(_currentObj);
        var weapon = _weaponDataStore.FindWithId(_selectData._weaponId);
        _currentObj = Instantiate(weapon.Obj, transform.position, transform.rotation, transform);
    }
}
