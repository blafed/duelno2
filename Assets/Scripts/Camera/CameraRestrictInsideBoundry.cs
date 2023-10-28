using UnityEngine;

namespace Duelno.Cameras
{
    public class CameraRestrictInsideBoundry : MonoBehaviour
    {
        public Rect boundryRect = new Rect(-10, -10, 20, 20);
        CameraObject cameraObject => CameraObject.instance;

        private void Update()
        {
            var cameraRect = cameraObject.camera;

            var cameraHalfHeight = cameraRect.orthographicSize;
            var cameraHalfWidth = cameraHalfHeight * cameraRect.aspect;


            var minX = boundryRect.min.x + cameraHalfWidth;
            var maxX = boundryRect.max.x - cameraHalfWidth;
            var minY = boundryRect.min.y + cameraHalfHeight;
            var maxY = boundryRect.max.y - cameraHalfHeight;

            var pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
    }
}