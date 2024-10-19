using UnityEngine;

/// <summary> WeaponDataの管理 </summary>
[CreateAssetMenu(menuName = "ScriptableObject / Weapon")]
public class WeaponDataBase : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _ogj;
    [SerializeField] private int _damage;
    [SerializeField] private int _id;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _animName;

    public string Name => _name;
    public GameObject Obj => _ogj;
    public int Damage => _damage;
    public int Id => _id;
    public Sprite Sprite => _sprite;
    public string AnimName => _animName;
}
