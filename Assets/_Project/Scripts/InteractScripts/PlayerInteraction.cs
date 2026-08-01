using System.Collections;
using _Project.Scripts.DialogueSystem.DialogueWithSalerScripts;
using _Project.Scripts.InventoryScripts;
using UnityEngine;

namespace _Project.Scripts.InteractScripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] float interactionDistance = 1f;
        [SerializeField] Camera mainCamera;

        public GameObject interactionUI;

        [SerializeField] LayerMask interactionMask;

        //public int countPurchasesItemsFromShop = 0;

        bool hitSomething = false;

        float interval = .01f;

        Coroutine checkCoroutine;

        [Header("References From Other Classes")]
        [SerializeField] DialogueWithSaler dialogueWithSaler;

        /*private void Start()
        {
            if(checkCoroutine == null)
                checkCoroutine = StartCoroutine(CheckRaycastHitCoroutine());
        }

        IEnumerator CheckRaycastHitCoroutine()
        {
            while (true)
            {
                InteractionRay();
                yield return new WaitForSeconds(interval);
            }
        }*/

        private void Update()
        {
            InteractionRay();
        }

        public void InteractionRay()
        {
            Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

            if (Physics.Raycast(ray, out hit, interactionDistance, interactionMask) &&
                hit.collider.TryGetComponent(out IInteractable interactable))
            {
                hitSomething = true;
                interactable.Description();

                if (Input.GetKeyDown(KeyCode.F) && dialogueWithSaler.isStartDialogue == false)
                {
                    Debug.Log("Key F was pressed");
                    interactable.Interact();

                    // iteration items in notepad for check complete mission
                    CounterAddItemsController.CounterAddSurvivalItems(hit);
                }
            }
            else
                hitSomething = false;

            interactionUI.SetActive(hitSomething);
        }

        /*private void OnDestroy()
        {
            if(checkCoroutine != null)
                StopCoroutine(checkCoroutine);
        }*/
    }
}

