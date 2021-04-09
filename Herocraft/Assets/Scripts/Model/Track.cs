using UnityEngine;
using System.Collections.Generic;


public class Track : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _purposePoint;
    [SerializeField] private BezierCurves _bezierCurves;

    public List<CheckPoint> _checkPoints;

    public void Awake()
    {
        _checkPoints = new List<CheckPoint>();

        var points = FindObjectsOfType<CheckPoint>();

        foreach (CheckPoint point in points)
        {
            _checkPoints.Add(point);
        }
    }

    public Vector3 GetPurposePoint(float speed)
    {
        _purposePoint.position = _bezierCurves.GetPointPosition(speed);
        return _purposePoint.position;
    }

    public Transform GetStartPoint()
    {
        return _startPoint;
    }
}
