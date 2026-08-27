using UnityEngine;

namespace _Project.Scripts.ImageScripts
{
    // скрипт отвечающий за поворот картинок в сторону камеры персонажа для предметов взаимодействия
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