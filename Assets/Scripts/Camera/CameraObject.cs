using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Duelno
{
    using Cameras;
    public class CameraObject : MonoBehaviour
    {
        static CameraObject _instance;
        public static CameraObject instance => _instance ? _instance : _instance = FindObjectOfType<CameraObject>(true);
        public new Camera camera => _camera ? _camera : _camera = GetComponentInChildren<Camera>();


        public CameraFollow cameraFollow { get; private set; }
        public CameraRestrictInsideBoundry cameraRestrictInsideBoundry { get; private set; }


        public Vector2 position
        {
            get => transform.position;
            set => transform.position = value;
        }

        Camera _camera;


        private void Awake()
        {
            cameraFollow = GetComponentInChildren<CameraFollow>();
            cameraRestrictInsideBoundry = GetComponentInChildren<CameraRestrictInsideBoundry>();
        }
    }

}