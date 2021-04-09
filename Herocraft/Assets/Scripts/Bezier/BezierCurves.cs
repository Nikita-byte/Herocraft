using UnityEngine;
using System.Collections.Generic;


[ExecuteInEditMode]
public class BezierCurves : MonoBehaviour
{
    [SerializeField] private BezierCurvesComponent _bezierCurvesComponent;
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private BezierCurvesComponent[] _point;
    [SerializeField] private Vector3[] _bezierPath;
    [SerializeField] private int _segmentCount = 25;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform _checkPosition;

    private UI _ui;
    private float _speedCoefficient;
    private List<Vector3> _pointsInPath;
    private BezierCurvesComponent _last;
    private Vector3 _lastPos;
    private int id;

    public float _t;

    private void Awake()
    {
        _speedCoefficient = CarData.Instance.SpeedCoefficient;
        _t = 0;
        _ui = FindObjectOfType<UI>();
        _pointsInPath = new List<Vector3>();
        bool sw = true;

        for (int i = 1; i < _point.Length; i++)
        {
            if (_pointsInPath.Count == 0)
            {
                _pointsInPath.Add(_point[i - 1].EndPoint.position);
                _pointsInPath.Add(_point[i - 1].AdjustPoint.position);
                _pointsInPath.Add(_point[i].AdjustPoint.position);
            }
            else if (!sw)
            {
                _pointsInPath.Add(_point[i - 1].AdjustMirror.position);
                _pointsInPath.Add(_point[i].AdjustMirror.position);
            }
            else
            {
                _pointsInPath.Add(_point[i - 1].AdjustPoint.position);
                _pointsInPath.Add(_point[i].AdjustPoint.position);
            }

            _pointsInPath.Add(_point[i].EndPoint.position);
            sw = !sw;
        }
    }

    private void Start()
    {
        _t = 0;
        _pointsInPath = new List<Vector3>();
        bool sw = true;

        for (int i = 1; i < _point.Length; i++)
        {
            if (_pointsInPath.Count == 0)
            {
                _pointsInPath.Add(_point[i - 1].EndPoint.position);
                _pointsInPath.Add(_point[i - 1].AdjustPoint.position);
                _pointsInPath.Add(_point[i].AdjustPoint.position);
            }
            else if (!sw)
            {
                _pointsInPath.Add(_point[i - 1].AdjustMirror.position);
                _pointsInPath.Add(_point[i].AdjustMirror.position);
            }
            else
            {
                _pointsInPath.Add(_point[i - 1].AdjustPoint.position);
                _pointsInPath.Add(_point[i].AdjustPoint.position);
            }

            _pointsInPath.Add(_point[i].EndPoint.position);
            sw = !sw;
        }
    }

    public void AddPoint()
    {
        _point = new BezierCurvesComponent[transform.childCount + 1];

        for (int i = 0; i < transform.childCount; i++)
        {
            _point[i] = transform.GetChild(i).GetComponent<BezierCurvesComponent>();
        }

        if (_last)
        {
            _lastPos = _last.transform.position;
        }

        _last = Instantiate(_bezierCurvesComponent) as BezierCurvesComponent;
        _last.gameObject.name = "BezierPoint_" + id;

        if (_point.Length > 1)
        {
            _last.transform.position = _lastPos + _offSet;
        }
        else
        {
            _last.transform.position = transform.position;
        }

        _last.transform.parent = transform;
        _point[_point.Length - 1] = _last;

        id++;
    }

    public void ClearAll()
    {
        for (int i = 0; i < _point.Length; i++)
        {
            if (_point[i])
            {
                DestroyImmediate(_point[i].gameObject);
            }
        }

        _point = new BezierCurvesComponent[0];
        id = 0;
        DrawCurves();
    }

    public void DestroyLast()
    {
        if (_last == null)
        {
            return;
        }

        DestroyImmediate(_last.gameObject);

        _lastPos -= _offSet;

        _point = new BezierCurvesComponent[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _point[i] = transform.GetChild(i).GetComponent<BezierCurvesComponent>();
            _last = _point[i];
        }

        id--;
        DrawCurves();
    }

#if UNITY_EDITOR
    private void LateUpdate()
    {
        if (_point.Length < 2 || _segmentCount < 6) return;

        if (_segmentCount > 1000)
        {
            _segmentCount = 1000;
        }

        DrawCurves();

        _checkPosition.position = CalculateBezierPoint.CalculateArray(_t, _pointsInPath);
    }
#endif

    public void DrawCurves()
    {
        bool sw = true;
        List<Vector3> p = new List<Vector3>();
        List<Vector3> l = new List<Vector3>();

        for (int i = 1; i < _point.Length; i++)
        {
            if (p.Count == 0)
            {
                p.Add(_point[i - 1].EndPoint.position);
                p.Add(_point[i - 1].AdjustPoint.position);
                p.Add(_point[i].AdjustPoint.position);
            }
            else if (!sw)
            {
                p.Add(_point[i - 1].AdjustMirror.position);
                p.Add(_point[i].AdjustMirror.position);
            }
            else
            {
                p.Add(_point[i - 1].AdjustPoint.position);
                p.Add(_point[i].AdjustPoint.position);
            }

            p.Add(_point[i].EndPoint.position);
            sw = !sw;
        }

        for (int i = 0; i < p.Count - 3; i += 3)
        {
            if (l.Count > 0)
            {
                l.RemoveAt(l.Count - 1);
            }

            for (int j = 0; j <= _segmentCount; j++)
            {
                float t = (float)j / _segmentCount;
                Vector3 pxl = CalculateBezierPoint.Calculate(t, p[i], p[i + 1], p[i + 2], p[i + 3]);
                l.Add(pxl);
            }
        }

        _bezierPath = new Vector3[] { };
        _bezierPath = l.ToArray();
        //_line.SetVertexCount(_bezierPath.Length);
        _line.positionCount = _bezierPath.Length;
        _line.SetPositions(_bezierPath);
    }

    public Vector3 GetPointPosition(float speed)
    {
        _t += speed / _speedCoefficient;
        //_t = speed;
        _ui.TextTable.SetT(_t.ToString());



        if (_t > _point.Length - 1)
        {
            _t = _point.Length - 1;
        }
        else if (_t < 0)
        {
            _t = 0;
        }

        return CalculateBezierPoint.CalculateArray(_t, _pointsInPath);
    }
}