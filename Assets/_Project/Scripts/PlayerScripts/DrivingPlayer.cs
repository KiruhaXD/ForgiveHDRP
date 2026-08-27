using System.Collections;
using _Project.Scripts.InteractScripts.CarInteractScripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

namespace _Project.Scripts.PlayerScripts
{
    public class DrivingPlayer : MonoBehaviour
    {
        public const string HoldKeyF = "hold_key_f";
        public const string RigBuilderListCountKey = "rig_builder_list_count";

        [SerializeField] Animator playerAnimator;
        [SerializeField] Animator carAnimator;
        [SerializeField] AnimationClip playerAnimationClip;

        [SerializeField] Transform playerTransform;

        //[SerializeField] CharacterController characterController;

        public Image imageInteractHold;

        [SerializeField] RigBuilder rigBuilder;

        [SerializeField] SphereCollider sphereColliderLeftDoor;


        //[HideInInspector]
        public bool isInCar = false;

        public int isHoldKeyF = 0; // false
        public int rigBuilderCount = 0;

        [Header("References From Other Classes")]
        [SerializeField] InteractionDoorCar interactionDoorCar;

        private void Awake()
        {
            imageInteractHold.gameObject.SetActive(false);

            if (isInCar == true)
            {
                playerAnimator.SetBool("isDriving", true);
            }
        }

        private void Update()
        {
            sphereColliderLeftDoor.enabled = !isInCar; // off interaction UI icon

            if (Input.GetKey(KeyCode.F) && imageInteractHold.fillAmount < 1 && imageInteractHold.gameObject.activeSelf == true
            && isHoldKeyF == 0)
            {
                imageInteractHold.fillAmount += 0.4f * Time.deltaTime;

                imageInteractHold.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 6f);


                if (imageInteractHold.fillAmount == 1)
                {
                    imageInteractHold.gameObject.SetActive(false);
                    ExitingCar();

                    isHoldKeyF = 1; // hold key end
                }

            }

            else if (imageInteractHold.fillAmount < 1 && imageInteractHold.gameObject.activeSelf == true)
            {
                imageInteractHold.fillAmount -= 0.2f * Time.deltaTime;

                imageInteractHold.transform.DOScale(new Vector3(1f, 1f, 1f), 6f);
            }
        }

        public void ExitingCar()
        {
            for (int i = 1; i < rigBuilder.layers.Count; i++)
            {
                rigBuilder.layers[i].active = false;
            }

            carAnimator.SetBool("isOpenDoor", true);
            playerAnimator.SetBool("isExitingCar", true);
            StartCoroutine(EndPlayAnimationExitingCarCoroutine());

        }

        IEnumerator EndPlayAnimationExitingCarCoroutine()
        {
            yield return new WaitForSeconds(7);

            playerAnimator.SetBool("isIdle", true);
            playerAnimator.SetBool("isDriving", false);

            carAnimator.SetBool("isOpenDoor", false);

            isInCar = false;
        }

        [ContextMenu("Reset Key Driver (Польз.)")]
        public void DeleteKeys()
        {
            PlayerPrefs.DeleteKey(HoldKeyF);
            PlayerPrefs.DeleteKey(RigBuilderListCountKey);

            Debug.Log("Удаление ключей Водителя");
        }

    }
}