using UnityEditor;
using UnityEngine;

/// <summary> 敵の目のセンサー </summary>
public class EyeSensor : MonoBehaviour
{
    [SerializeField] private SphereCollider _searchArea;
    [SerializeField] private float _searchAngle;
    [SerializeField] private GameObject _controller;
    [SerializeField] private EnemyController _enemyController;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player発見");
            var playerDirection = other.transform.position - transform.position;
            var angle = Vector3.Angle(transform.forward, playerDirection);
            
            if (angle <= _searchAngle) // 視野角内
            {
                _controller.transform.position = 
                    Vector3.Lerp(_controller.transform.position, other.gameObject.transform.position, 0.1f);
                _enemyController.ChangeStateByPlayerPos(other.gameObject.transform, true);
            }
            else
            {
                _controller.transform.position = Vector3.Lerp(_controller.transform.position, transform.position, 0.1f);
                _enemyController.ChangeStateByPlayerPos(other.gameObject.transform, false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Playerを見失いました");
        _controller.transform.position = transform.position;
        _enemyController.ChangeStateByPlayerPos(other.gameObject.transform, true);
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -_searchAngle, 0f)*transform.forward, _searchAngle*2f, _searchArea.radius);
    }
}
