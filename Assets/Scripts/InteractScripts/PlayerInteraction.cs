using UnityEngine;

namespace Scripts.InteractScripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] float interactionDistance = 10f;
        [SerializeField] Camera mainCamera;

        [SerializeField] GameObject interactionUI;

        private void Update()
        {
            InteractionRay();
        }

        public void InteractionRay()
        {
            RaycastHit hit;
        
            bool hitSomething = false;
        
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
                if (hit.collider != null && hit.collider.tag == "ItemsInteractionForCarRepair" 
                    || hit.collider.tag == "Saler" || hit.collider.tag == "ItemsInteractionForSurvivalInNight" || hit.collider.tag == "Car")
                {
                    interactable.Interact();
                    interactable.Description();
                    hitSomething = true;
                }
            }
            interactionUI.SetActive(hitSomething);
        
        }
    }
}

