using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    [Header("Parent Object")]
    [SerializeField] GameObject parentObject;

    [Header("Child Object")]
    [SerializeField] GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out DrivingPlayer drivingPlayer))
        {
            drivingPlayer.isInCar = true;

            if (drivingPlayer.isHoldKeyF == 1)
            {
                drivingPlayer.isInCar = false;
                player.transform.SetParent(parentObject.transform);
                player.transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
                drivingPlayer.rbDriver.isKinematic = false;
            }
        }
    }
}
