using UnityEngine;

/// <summary> Listから検索をしてくれる </summary>
public class WeaponDataStore : MonoBehaviour
{
    [SerializeField] private WeaponDataBaseList _weaponDataBaseList;
    
    public WeaponDataBase FindWithId(int id)
    {
        return _weaponDataBaseList.WeaponDataBase.Find(e => e.Id == id);
    }
}
