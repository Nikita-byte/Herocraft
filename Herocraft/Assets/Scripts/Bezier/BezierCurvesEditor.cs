#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(BezierCurves))]
class BezierCurvesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BezierCurves e = (BezierCurves)target;

        GUILayout.Space(15);
        if (GUILayout.Button("Add New"))
        {
            e.AddPoint();
        }

        GUILayout.Space(5);
        if (GUILayout.Button("Clear All"))
        {
            e.ClearAll();
        }
    }
}
#endif
