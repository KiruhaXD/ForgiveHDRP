using System.Collections;
using UnityEngine;

namespace Scripts.InteractScripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] float interactionDistance = 1f;
        [SerializeField] Camera mainCamera;

        [SerializeField] public GameObject interactionUI;

        [SerializeField] LayerMask interactionMask;

        //public int countPurchasesItemsFromShop = 0;

        bool hitSomething = false;

        float interval = .01f;

        Coroutine checkCoroutine;

        private void Start()
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
        }

        public void InteractionRay()
        {
            Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

            if (Physics.Raycast(ray, out hit, interactionDistance, interactionMask))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable)) 
                {
                    hitSomething = true;
                    interactable.Description();

                    if(Input.GetKeyDown(KeyCode.F))
                        interactable.Interact();
                }

                else
                    hitSomething = false;
            }
            else
                hitSomething = false;

            interactionUI.SetActive(hitSomething);
        }

        private void OnDestroy()
        {
            if(checkCoroutine != null)
                StopCoroutine(checkCoroutine);
        }
    }
}

