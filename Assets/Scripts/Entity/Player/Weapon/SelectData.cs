using UnityEngine;

/// <summary> 選択されたデータの保存 </summary>
[CreateAssetMenu(menuName = "ScriptableObject / SelectData")]
public class SelectData : ScriptableObject
{
    public int _weaponId { get; set; }
}
