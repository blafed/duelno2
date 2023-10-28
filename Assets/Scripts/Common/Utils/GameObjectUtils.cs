using UnityEngine;
public static class GameObjectUtils
{
    public static T GetComponentOrAdd<T>(this GameObject go) where T : Component
    {
        T comp = go.GetComponent<T>();
        if (comp) return comp;
        return go.AddComponent<T>();
    }

    public static void SetLayerRecursive(this GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform t in go.transform)
        {
            SetLayerRecursive(t.gameObject, layer);
        }
    }
    public static T CachedComponent<T>(this GameObject go, ref T cache)
    {
        if (cache != null)
            return cache;
        return cache = go.GetComponent<T>();
    }
    public static T CachedComponentInParent<T>(this GameObject go, ref T cache)
    {
        if (cache != null)
            return cache;
        return cache = go.GetComponentInParent<T>();
    }

    public static T RemoveComponentIfExists<T>(this GameObject go) where T : Component
    {
        var comp = go.GetComponent<T>();
        if (comp)
            GameObject.Destroy(comp);
        return comp;
    }
}
