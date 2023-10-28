using UnityEngine;
public static class CameraUtils
{
    public static Vector2 GetLimitCameraPosition2D(Camera camera, Rect worldRect, Vector2 position)
    {
        // Calculate the camera's world rect based on the screen size and camera size
        float height = camera.orthographicSize * 2f;
        float width = height * camera.aspect;
        Rect cameraWorldRect = new Rect(camera.transform.position.x - width / 2f, camera.transform.position.y - height / 2f, width, height);

        // Calculate the minimum and maximum positions for the camera
        float minX = worldRect.xMin + cameraWorldRect.width / 2f;
        float maxX = worldRect.xMax - cameraWorldRect.width / 2f;
        float minY = worldRect.yMin + cameraWorldRect.height / 2f;
        float maxY = worldRect.yMax - cameraWorldRect.height / 2f;

        // Limit the camera's position to the world rect
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        return position;
    }

    public static Rect GetWorldRect(this Camera camera)
    {
        float height = camera.orthographicSize * 2f;
        float width = height * camera.aspect;

        return new Rect(camera.transform.position.x - width / 2f, camera.transform.position.y - height / 2f, width, height);
    }
}