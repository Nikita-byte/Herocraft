using UnityEngine;

[ExecuteInEditMode]
public class BezierCurvesAdjustment : MonoBehaviour
{
    [SerializeField] private Transform _mirror;
    [SerializeField] private Transform _parent;
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private float _scale = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawCube(transform.position, Vector3.one * _scale);
        Gizmos.DrawSphere(_mirror.transform.position, _scale / 2);
        Gizmos.DrawLine(transform.position, _mirror.position);
    }

#if UNITY_EDITOR
    private void LateUpdate()
    {
        _mirror.position = _parent.position + (transform.localPosition * -1);
    }
#endif
}
