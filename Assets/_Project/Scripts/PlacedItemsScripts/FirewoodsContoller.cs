using UnityEngine;

namespace _Project.Scripts.PlacedItemsScripts
{
    public class FirewoodsContoller : PlacedInteractionItemsManager, IInteractableBuildings
    {
        [SerializeField] ParticleSystem particleSystemFire;

        public void InteractBuildings()
        {
            // on effects for fire
            particleSystemFire.Play();
            playerInteraction.isShowDescription = false;

            if (playerInteraction.isShowDescription == false)
                DisableLayer();
        }

        public void DescriptionBuildings()
        {
            if (playerInteraction.isShowDescription == true)
                textInteraction.text = "light a fire";
        }
    }
}