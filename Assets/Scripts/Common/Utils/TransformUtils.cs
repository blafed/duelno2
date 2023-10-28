using UnityEngine;


public static class TransformUtils
{
    public static void AssignTo(this Transform transform, Transform parent, Vector2 offset, float angleOffset)
    {
        transform.SetParent(parent);
        transform.localPosition = offset;
        transform.localRotation = Quaternion.Euler(0, 0, angleOffset);
    }

}