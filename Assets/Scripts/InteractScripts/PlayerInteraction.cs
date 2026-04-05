using UnityEngine;

namespace Scripts.InteractScripts
{
    public class PlayerInteraction : MonoCache
    {
        [SerializeField] float interactionDistance = 15f;
        [SerializeField] Camera mainCamera;

        [SerializeField] GameObject interactionUI;

        public override void OnTick()
        {
            InteractionRay();
        }

        // луч касается объетов только после приседа, а должен всегда
        public void InteractionRay()
        {
            RaycastHit hit;
        
            bool hitSomething = false;

            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.red);

            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
                if (hit.collider != null && hit.collider.tag == "ItemsInteractionForCarRepair" 
                    || hit.collider.tag == "Saler" || hit.collider.tag == "ItemsInteractionForSurvivalInNight" || hit.collider.tag == "Car")
                {
                    interactable.Description();
                    hitSomething = true;

                    if(Input.GetKeyDown(KeyCode.F))
                        interactable.Interact();
                }
            }
            interactionUI.SetActive(hitSomething);
        
        }
    }
}

