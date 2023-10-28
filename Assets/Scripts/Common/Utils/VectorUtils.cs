using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public static class VectorUtils
{


    ///Vector3
    public static Vector3 addX(this Vector3 v, float f) => v.setX(v.x + f);
    public static Vector3 addY(this Vector3 v, float f) => v.setY(v.y + f);
    public static Vector3 addZ(this Vector3 v, float f) => v.setZ(v.z + f);
    public static Vector3Int toInt(this Vector3 v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);
    public static void writeToArray(this Vector3 v, IList<float> f, int startAt = 0, int length = 3)
    {
        for (int i = 0; i < length; i++)
        {
            var j = startAt + i;
            if (j < f.Count)
                f[j] = v[i];
        }
    }
    public static float[] toFloatArray(this Vector3 v)
    {
        return new[] { v.x, v.y, v.z };
    }
    public static Vector3Int roundToInt(this Vector3 v)
    {
        return new Vector3Int(v.x.roundToInt(), v.y.roundToInt(), v.z.roundToInt());
    }
    public static Vector3 inverse(this Vector3 v)
    {
        return new Vector3(1 / v.x, 1 / v.y
        , 1 / v.z);
    }
    public static Vector2 toVector2(this Vector3 v) => (Vector2)v;

    public static void drawGizmos(this Vector3 v, Color color = default(Color), float width = 0.15f)
    {
        if (color != default(Color))
            Gizmos.color = color;
        Gizmos.DrawWireSphere(v, width);
    }
    public static Vector3 setX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
    public static Vector3 setY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
    public static Vector3 setZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);
    public static float maxComp(this Vector3 v)
    {
        return Mathf.Max(v.x, Mathf.Max(v.y, v.z));
    }

    public static float minComp(this Vector3 v)
    {
        return Mathf.Min(v.x, Mathf.Min(v.y, v.z));

    }
    public static Vector3 abs(this Vector3 v)
    {
        return new Vector3(v.x.abs(), v.y.abs(), v.z.abs());
    }
    public static bool approx(this Vector3 v, Vector3 other)
    {
        return Mathf.Approximately(v.x, other.x) && Mathf.Approximately(v.y, other.y) &&
                     Mathf.Approximately(v.z, other.z);
    }


    #region Vector2

    public static Vector3 toVector3(this Vector2 v, float z = 0) => new Vector3(v.x, v.y, z);
    public static Vector3 flatten(this Vector2 v, float y = 0) => new Vector3(v.x, y, v.y);

    public static float ratio(this Vector2 v) => v.x / v.y;

    #endregion



    //Vector2Int
    public static void iterate(this Vector2Int size, Action<Vector2Int> action)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                action(new Vector2Int(x, y));
            }
        }
    }
    /// <summary>
    /// It's exclusive
    /// </summary>
    public static bool Between(Vector2Int point, Vector2Int min, Vector2Int max)
    {
        return point.x >= min.x && point.y >= min.y && point.x < max.x && point.y < max.y;
    }
    public static Vector2 toVector2(this Vector2Int v) => new Vector2(v.x, v.y);


    public static Vector2 optainPosition(this Vector2Int tileIndex, Vector2 tileSize, bool atCenter, Vector2 offset = default)
    {
        return Vector2.Scale((Vector2)tileIndex, tileSize) + (atCenter ? tileSize / .5f : Vector2.zero) + offset;
    }

    public static Vector3Int toVector3Int(this Vector2Int v) => new Vector3Int(v.x, v.y, 0);
    public static Vector2Int divide(this Vector2Int v, Vector2Int other) => new Vector2Int(v.x / other.x, v.y / other.y);
    public static float ratio(this Vector2Int v) => (float)v.x / v.y;

}