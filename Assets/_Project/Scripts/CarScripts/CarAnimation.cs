using UnityEngine;

namespace _Project.Scripts.CarScripts
{

    public class CarAnimation : MonoBehaviour
    {
        [SerializeField] DrivingPlayer drivingPlayer;

        public void StopAnimation() => drivingPlayer.imageInteractHold.gameObject.SetActive(true);
    }
}