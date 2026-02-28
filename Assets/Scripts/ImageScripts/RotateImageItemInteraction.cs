using UnityEngine;

namespace Scripts.ImageScripts
{
    public class RotateImageItemInteraction : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;

        private void Update()
        {
            RotateImageItem();
        }

        public void RotateImageItem() => transform.rotation = mainCamera.transform.rotation;
    }
}