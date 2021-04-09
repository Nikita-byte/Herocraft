using UnityEngine;


public class BezierCurvesComponent : MonoBehaviour
{
    public Transform AdjustMirror;
    public Transform AdjustPoint;
    public Transform EndPoint;

    [SerializeField] private Color _color = Color.white;
    [SerializeField] private float _scale = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _scale/4);
    }
}
