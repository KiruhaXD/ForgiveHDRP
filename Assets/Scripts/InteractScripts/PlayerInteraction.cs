using UnityEngine;

namespace Scripts.InteractScripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] float interactionDistance = 100f;
        [SerializeField] Camera mainCamera;

        [SerializeField] GameObject interactionUI;

        private void Update()
        {
            InteractionRay();
        }

        // луч касается объетов только после приседа, а должен всегда
        public void InteractionRay()
        {
            RaycastHit hit;

            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.red);

            bool hitSomething = false;

            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
            {

                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
                if (hit.collider != null && (hit.collider.tag == "ItemsInteractionForCarRepair" 
                    || hit.collider.tag == "Saler" || hit.collider.tag == "ItemsInteractionForSurvival" || hit.collider.tag == "Car"
                    || hit.collider.tag == "Door"))
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

