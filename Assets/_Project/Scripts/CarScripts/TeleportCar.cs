using System.Collections;
using _Project.Scripts.InteractScripts.CarInteractScripts;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Project.Scripts.CarScripts
{
    // скрипт отвечающий за телепорт машины в нужные локации и места
    public class TeleportCar : MonoBehaviour
    {
        [Header("Transform Point For Teleport (Old First Location)")]
        [SerializeField] Transform pointTeleportCarForDriveToNextLocation;
        [SerializeField] Transform pointTeleportPlayerInCar;

        [Header("Transform Point For Teleport (New Second Location)")]
        [SerializeField] Transform pointTeleportCarInNextLocation;

        [Header("Transform Car And Player")]
        [SerializeField] Transform carTransform;
        [SerializeField] Transform playerTransform;

        [Header("Animator")]
        [SerializeField] Animator playerAnimator;
        [SerializeField] Animator carAnimator;

        [Header("References From Other Classes")]
        [SerializeField] InteractionDoorCar interactionDoorCar;
        [SerializeField] TransitionsController transitionsController;

        [Header("Parent Object")]
        [SerializeField] Transform parentCarObject;

        [Header("Child Object")]
        [SerializeField] Transform childPlayerObject;

        [Header("Rig Builder")]
        [SerializeField] RigBuilder rigBuilder;

        [Header("Border First Location")]
        [SerializeField] GameObject borderLocation;

        [Header("Old(First) Location")]
        [SerializeField] GameObject firstLocation;

        [Header("New(Second) Location")]
        [SerializeField] GameObject secondLocation;

        [HideInInspector]
        public bool isHasNewLocation = false;

        Quaternion playerRotationInCar = new Quaternion(0f, 180f, 0f, 0f);

        public void TeleportToPointOldLocation()
        {
            borderLocation.SetActive(false);

            carAnimator.enabled = false; // для работы телепорта, т.к из-за аниматора машины она не телепортируется

            carTransform.position = pointTeleportCarForDriveToNextLocation.position;

            childPlayerObject.SetParent(parentCarObject);

            playerTransform.position = pointTeleportPlayerInCar.position;
            playerTransform.rotation = playerRotationInCar;

            playerAnimator.SetBool("isDriving", true);

            for (int i = 1; i < rigBuilder.layers.Count && i != 5; i++)
            {
                rigBuilder.layers[i].active = true;
            }

            StartCoroutine(EnableOldLocationCarAnimationDrivingCoroutine());

            Debug.Log("teleport complete");

        }

        public void TeleportToNewLocation() 
        {
            firstLocation.SetActive(false);

            carAnimator.enabled = false; // для работы телепорта, т.к из-за аниматора машины она не телепортируется

            secondLocation.SetActive(true);

            carTransform.position = pointTeleportCarInNextLocation.position;

            childPlayerObject.SetParent(parentCarObject);

            isHasNewLocation = true;

            StartCoroutine(EnableNewLocationCarAnimationDrivingCoroutine());
        }

        // в первой локе
        IEnumerator EnableOldLocationCarAnimationDrivingCoroutine() 
        {
            yield return new WaitForSeconds(1f);

            carAnimator.enabled = true;
            carAnimator.SetBool("isDrivingToNewLocation", true);

        }

        // во второй локе
        IEnumerator EnableNewLocationCarAnimationDrivingCoroutine()
        {
            yield return new WaitForSeconds(1f);

            carAnimator.enabled = true;
            carAnimator.SetBool("isDrivingToDirtRoad", true);

        }
    }
}