using UnityEngine;
using UnityEngine.UI;

/// <summary> inventoryのslot </summary>
public class Slot : MonoBehaviour
{
    [SerializeField, Header("画像をおくGameObjectの名前")] private string _imageName;
    [SerializeField, Header("名前を書くGameObjectの名前")] private string _textName;
    [SerializeField, Header("select画面をだすボタンの名前")] private string _buttonName;
    [SerializeField] private WeaponDataStore _weaponDataStore;
    
    public int _id { get; private set; }
    private Image _image = default;
    private Text _text = default;
    private GameObject _selectButton = default;

    private void Awake()
    {
        _image = transform.Find(_imageName).GetComponent<Image>();
        _text = transform.Find(_textName).GetComponent<Text>();
        _selectButton = transform.Find(_buttonName).gameObject;
    }

    /// <summary> slotに表示する </summary>
    /// <param name="id"> 武器のid </param>
    public void Add(int id)
    {
        var weapon = _weaponDataStore.FindWithId(id);
        _id = id;
        _image.sprite = weapon.Sprite;
        _text.text = weapon.Name;
        _selectButton.SetActive(true);
    }
}