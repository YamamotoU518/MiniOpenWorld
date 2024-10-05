using System.Collections.Generic;
using UnityEngine;

/// <summary> Weaponのデータをリストで管理 </summary>
[CreateAssetMenu(menuName = "ScriptableObject / WeaponDataBaseList")]
public class WeaponDataBaseList : ScriptableObject
{
    [SerializeField] private List<WeaponDataBase> _weaponDataBaseList = new();

    public List<WeaponDataBase> WeaponDataBase => _weaponDataBaseList;
}
