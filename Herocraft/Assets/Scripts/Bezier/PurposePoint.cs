using UnityEngine;


public class PurposePoint : MonoBehaviour
{
    [SerializeField] private BezierCurves _bezierCurves;
    [SerializeField] private float _t;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _deceleration;

    private void Start()
    {
        _speed = 0;
    }

    private void Update()
    {
        transform.position = _bezierCurves.GetPointPosition(_speed);
    }
}
