using System.Collections;
using UnityEngine;
public static class ColorUtils
{
    public static Color setAlpha(this Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }
}