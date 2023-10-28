using UnityEngine;
public static class FloatUtils
{
    public static float squared(this float f) => f * f;
    public static float clamp01(this float f) => Mathf.Clamp01(f);
    public static float abs(this float f) => Mathf.Abs(f);
    public static int roundToInt(this float f) => Mathf.RoundToInt(f);
    public static float round(this float f) => Mathf.Round(f);
    public static bool approx(this float f, float o) => Mathf.Approximately(f, o);
}