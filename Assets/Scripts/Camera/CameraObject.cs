using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Duelno
{
    using Cameras;
    public class CameraObject : SingletonScene<CameraObject>
    {
        public new Camera camera => _camera ? _camera : _camera = GetComponentInChildren<Camera>();


        public CameraFollow cameraFollow { get; private set; }
        public CameraRestrictInsideBoundry cameraRestrictInsideBoundry { get; private set; }


        public Vector2 position
        {
            get => transform.position;
            set => transform.position = value;
        }

        Camera _camera;


        protected override void OnAwake()
        {
            cameraFollow = GetComponentInChildren<CameraFollow>();
            cameraRestrictInsideBoundry = GetComponentInChildren<CameraRestrictInsideBoundry>();
        }
        private void Start()
        {
            ResetScriptState();
        }


        public void ResetScriptState()
        {
            cameraFollow.enabled = false;
            cameraRestrictInsideBoundry.enabled = false;
        }
    }

}