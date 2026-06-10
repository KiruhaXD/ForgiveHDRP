using UnityEngine;

namespace Scripts.InteractScripts
{
    public class PlayerInteraction : MonoCache
    {
        [SerializeField] float interactionDistance = 3f;
        [SerializeField] Camera mainCamera;

        [SerializeField] GameObject interactionUI;

        public int countPurchasesItemsFromShop = 0;

        public override void OnTick()
        {
            InteractionRay();
        }

        public void InteractionRay()
        {
            RaycastHit hit;

            bool hitSomething = false;

            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.red);

            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (hit.collider != null &&
                    hit.collider.tag == "ItemsInteractionForCarRepair" || hit.collider.tag == "Saler" || hit.collider.tag == "ItemsInteractionForSurvival" ||
                    hit.collider.tag == "Car" || hit.collider.tag == "Door")
                {
                    interactable.Description();
                    hitSomething = true;

                    Debug.Log(hit.collider.tag);

                    if (Input.GetKeyDown(KeyCode.F))
                        interactable.Interact();
                }
            }
            interactionUI.SetActive(hitSomething);
        
        }
    }
}

