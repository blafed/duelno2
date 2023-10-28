using UnityEngine;

public static class RectUtils
{
    public static Rect FromCenter(Vector2 center, Vector2 size)
    {
        return new Rect(center.x - size.x / 2, center.y - size.y / 2, size.x, size.y);
    }

    public static Rect clampMaintainAspectRatio(this Rect rect, Rect clamp)
    {
        var aspectRatio = rect.width / rect.height;
        var clamped = rect.clamp(clamp);
        var clampedAspectRatio = clamped.width / clamped.height;

        if (clampedAspectRatio > aspectRatio)
        {
            clamped.width = clamped.height * aspectRatio;
        }
        else
        {
            clamped.height = clamped.width / aspectRatio;
        }

        return clamped;
    }
    public static Rect clamp(this Rect rect, Rect clamp)
    {
        rect.x = Mathf.Clamp(rect.x, clamp.xMin, clamp.xMax - rect.width);
        rect.y = Mathf.Clamp(rect.y, clamp.yMin, clamp.yMax - rect.height);


        rect.width = Mathf.Clamp(rect.width, 0, clamp.width);
        rect.height = Mathf.Clamp(rect.height, 0, clamp.height);



        return rect;
    }
}