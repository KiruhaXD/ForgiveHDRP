using Unity.Cinemachine;
using UnityEngine;

namespace Scripts.CameraScripts
{
    public class SwitchCamerasController : MonoBehaviour
    {
        [SerializeField] public CinemachineCamera[] cinemachineCameras;
        int currentCameraIndex = 0;

        public void SwitchCameras()
        {
            cinemachineCameras[currentCameraIndex].gameObject.SetActive(false);
            currentCameraIndex++;

            if (currentCameraIndex >= cinemachineCameras.Length)
            {
                currentCameraIndex = 0;
            }

            cinemachineCameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}