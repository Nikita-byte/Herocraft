using UnityEngine;
using System.Collections.Generic;


public static class CalculateBezierPoint
{
    public static Vector3 Calculate(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;
        return p;
    }

    public static Vector3 CalculateArray(float t, List<Vector3> p)
    {
        if (t <= 1)
        {
            return CalculateBezierPoint.Calculate(t, p[0], p[1], p[2], p[3]);
        }
        else if (t <= 2)
        {
            return CalculateBezierPoint.Calculate(t - 1, p[3], p[4], p[5], p[6]);
        }
        else if (t <= 3)
        {
            return CalculateBezierPoint.Calculate(t - 2, p[6], p[7], p[8], p[9]);
        }
        else if (t <= 4)
        {
            return CalculateBezierPoint.Calculate(t - 3, p[9], p[10], p[11], p[12]);
        }
        else if (t <= 5)
        {
            return CalculateBezierPoint.Calculate(t - 4, p[12], p[13], p[14], p[15]);
        }
        else if (t <= 6)
        {
            return CalculateBezierPoint.Calculate(t - 5, p[15], p[16], p[17], p[18]);
        }
        else if (t <= 7)
        {
            return CalculateBezierPoint.Calculate(t - 6, p[18], p[19], p[20], p[21]);
        }
        else if (t <= 8)
        {
            return CalculateBezierPoint.Calculate(t - 7, p[21], p[22], p[23], p[24]);
        }
        else if (t <= 9)
        {
            return CalculateBezierPoint.Calculate(t - 8, p[24], p[25], p[26], p[27]);
        }
        else if (t <= 10)
        {
            return CalculateBezierPoint.Calculate(t - 8, p[27], p[28], p[29], p[30]);
        }


        return Vector3.zero;
    }
}
