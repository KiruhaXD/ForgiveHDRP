using UnityEngine;

namespace Scripts.CameraScripts 
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _bodyPlayer;
        [SerializeField] Transform headPlayer;
        [SerializeField] SensivityController sensitivityController;
        [SerializeField] DrivingPlayer drivingPlayer;
        [SerializeField] Animator playerAnimator;

        float _yRotation = 0f;
        float _xRotation = 0f;

        float limitUpY = 70f, limitDownY = -60f;
        float limitRightX = 30f, limitLeftX = -30f;

        [SerializeField] Transform _headTarget;
        [SerializeField] Camera _mainCamera;

        float mouseX;
        float mouseY;

        private void Update()
        {
            PlayerRotateCamera();
        }

        public void PlayerRotateCamera() 
        {
            InputMouse();

            LimitsRotateCameraY();
            LimitsRotateCameraX();

            if (drivingPlayer.isInCar == false) 
            {
                transform.localRotation = Quaternion.Euler(_yRotation, _xRotation, 0f);

                if (limitLeftX == -30f || limitRightX == 30f) 
                {
                    _bodyPlayer.Rotate(Vector3.up * mouseX);
                    //AnimationRotateBody();
                }
            }

            CreateRayForHeadRotate();
        }

        public void CreateRayForHeadRotate()
        {
            Ray ray = _mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
            Vector3 positionTarget = ray.origin + ray.direction;
            _headTarget.position = positionTarget;

            transform.localRotation = Quaternion.Euler(_yRotation, _xRotation, 0f);
            //headPlayer.Rotate(positionTarget);
        }

        public void InputMouse() 
        {
            mouseX = Input.GetAxisRaw("Mouse X") * sensitivityController.currentSensivity * Time.smoothDeltaTime;
            mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityController.currentSensivity * Time.smoothDeltaTime;
        }

        public void LimitsRotateCameraY()
        {
            _yRotation -= mouseY;
            _yRotation = Mathf.Clamp(_yRotation, limitDownY, limitUpY);
        }

        public void LimitsRotateCameraX() 
        {
            _xRotation += mouseX;
            _xRotation = Mathf.Clamp(_xRotation, limitLeftX, limitRightX);
        }

        public void AnimationRotateBody() 
        {
            if (mouseX != 0) 
            {
                if (mouseX > 0)
                {
                    playerAnimator.SetBool("isRotateRightX", true);
                    playerAnimator.SetBool("isRotateLeftX", false);
                }

                else
                {
                    playerAnimator.SetBool("isRotateLeftX", true);
                    playerAnimator.SetBool("isRotateRightX", false);
                }
            }

            else if (mouseX == 0) 
            {
                playerAnimator.SetBool("isRotateRightX", false);
                playerAnimator.SetBool("isRotateLeftX", false);
            }
        }
    }
}

