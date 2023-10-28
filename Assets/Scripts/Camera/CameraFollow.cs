using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Duelno.Cameras
{

    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        private void LateUpdate()
        {
            if (!target)
                return;
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }



    }

}