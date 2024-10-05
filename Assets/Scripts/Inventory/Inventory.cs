using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Slot[] _slots;
    private List<int> _weaponDataBases = new List<int>(); // 持ってる武器のidのList
    
    private void Awake()
    {
        _slots = GetComponentsInChildren<Slot>();
    }

    private void Start()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    /// <summary> inventoryに武器を入れる </summary>
    /// <param name="id"> 入れたい武器のid </param>
    public void Add(int id)
    {
        _weaponDataBases.Add(id);
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < _weaponDataBases.Count; i++)
        {
            _slots[i].Add(_weaponDataBases[i]);
        }
    }
}