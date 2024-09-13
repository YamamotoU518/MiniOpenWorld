using UnityEngine;

/// <summary> 敵の目（のcontroller）の可動域の設定 </summary>
public class EyeContoller : MonoBehaviour
{
    [SerializeField] private Vector3 _posMin;

    [SerializeField] private Vector3 _posMax;

    [SerializeField] private Transform _playerTransform;

    private Vector3 _pos;
    
    private void Update()
    {
        _pos.x = Mathf.Clamp(transform.localPosition.x, _posMin.x, _posMax.x);
        _pos.y = Mathf.Clamp(transform.localPosition.y, _posMin.y, _posMax.y);
        _pos.z = Mathf.Clamp(transform.localPosition.z, _posMin.z, _posMax.z);
        transform.localPosition = _pos;
    }
}
