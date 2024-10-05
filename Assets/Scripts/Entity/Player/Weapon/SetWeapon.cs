using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 装備している武器をメニュー欄にセットする </summary>
public class SetWeapon : MonoBehaviour
{
    [SerializeField] private WeaponDataStore _weaponDataStore;
    [SerializeField] private SelectData _selectData;
    [SerializeField] private Image _image;
    [SerializeField] private Text _name;
    
    public void Set()
    {
        var weapon = _weaponDataStore.FindWithId(_selectData._weaponId);
        _image.sprite = weapon.Sprite;
        _name.text = weapon.Name;
    }
}
