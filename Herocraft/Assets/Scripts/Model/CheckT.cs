using UnityEngine;


[ExecuteInEditMode]
public class CheckT : MonoBehaviour
{
    [SerializeField] private BezierCurves _besierCurves;
    [SerializeField] private float _t;


#if UNITY_EDITOR

    private void Update()
    {
        _besierCurves._t = _t;
    }

#endif
}
