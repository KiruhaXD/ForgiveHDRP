using _Project.Scripts.PlayerScripts;
using UnityEngine;

namespace _Project.Scripts.CarScripts
{

    public class CarAnimation : MonoBehaviour
    {
        [SerializeField] DrivingPlayer drivingPlayer;

        public void ExitFromCar() => drivingPlayer.imageInteractHold.gameObject.SetActive(true);
    }
}