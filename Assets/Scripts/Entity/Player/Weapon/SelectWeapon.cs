using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 武器を装備する </summary>
public class SelectWeapon : MonoBehaviour
{
    [SerializeField] private SelectData _selectData;
    [SerializeField, Header("選ぶオブジェクト")] private Slot _slot;
    [SerializeField] private SetWeapon _setWeapon;
    [SerializeField] private UpdateWeapon _updateWeapon;
    
    public void Select()
    {
        _selectData._weaponId = _slot.GetComponent<Slot>()._id;
        _setWeapon.Set();
        _updateWeapon.Set();
    }
}
