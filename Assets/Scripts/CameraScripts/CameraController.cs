using UnityEngine;

namespace Scripts.CameraScripts 
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _bodyPlayer;
        [SerializeField] SensivityController sensitivityController;

        float _xRotation = 0f;

        [SerializeField] Transform _headTarget;
        [SerializeField] Camera _mainCamera;

        public Ray ray { get; private set; }

        private void Update()
        {
            CameraRotate();
            CreateRayForHeadRotate();
        }

        public void CreateRayForHeadRotate()
        {
            ray = _mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
            Vector3 positionTarget = ray.origin + ray.direction;
            _headTarget.position = positionTarget;
        }

        public void CameraRotate() 
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityController.currentSensivity * Time.smoothDeltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityController.currentSensivity * Time.smoothDeltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -60f, 70f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _bodyPlayer.Rotate(Vector3.up * mouseX);
        }
    }
}

