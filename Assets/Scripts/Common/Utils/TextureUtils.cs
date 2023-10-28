using System.Numerics;
using UnityEngine;

public static class TextureUtils
{

    public static Vector2Int size(this Texture2D texture)
    {
        return new Vector2Int(texture.width, texture.height);
    }
}