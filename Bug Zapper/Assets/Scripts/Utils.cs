using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static readonly float EPSILON = 0.01f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return (Mathf.Abs(a - b) < EPSILON);
    }

    public static float Clamp(this float val, float min, float max)
    {
        if (val < min)
            val = min;
        if (val > max)
            val = max;
        return val;
    }

    public static float AngleDiffPosNeg(float a, float b)
    {
        float diff = a - b;
        if (diff > 180)
            return diff - 360;
        if (diff < 180)
            return diff + 360;
        return diff;
    }
    
    public static float AngleBetween(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.z - a.z, b.x - a.x) * Mathf.Rad2Deg;
    }

    public static float Clamp360Degrees(this float angleDegrees)
    {
        while (angleDegrees >= 360)
            angleDegrees -= 360;
        while (angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }
}
