using _Project.Scripts;
using UnityEngine;

public class TriggerTeleportCarNextLocation : MonoBehaviour
{
    [SerializeField] TransitionsController transitionsController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) 
            transitionsController.StartCoroutine(transitionsController.DrivingToNewLocationCoroutine());
        
    }
}
