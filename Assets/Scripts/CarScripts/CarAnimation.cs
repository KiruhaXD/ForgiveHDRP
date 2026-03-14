using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    [SerializeField] DrivingPlayer drivingPlayer;

    public void StopAnimation() => drivingPlayer.imageInteractHold.gameObject.SetActive(true);
}
