using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField, Header("表示するmenuパネル")] private GameObject _menuPanel;

    private void Start()
    {
        _menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_menuPanel.activeSelf) CloseMenu();
            else ShowMenu();
        }
    }

    private void ShowMenu()
    {
        _menuPanel.gameObject.SetActive(true);
    }

    private void CloseMenu()
    {
        _menuPanel.gameObject.SetActive(false);
    }
}
