using _Project.Scripts.MissionsScripts;
using UnityEngine;

namespace _Project.Scripts.PlacedItemsScripts
{
    public class SleepingBagController : PlacedInteractionItemsManager, IInteractableBuildings
    {
        [SerializeField] TransitionsController transitionsController;
        [SerializeField] ShowMissionsManager showMissionsManager;

        private void Update()
        {
            if (buildingManager.nameItemForBuilding == "SleepingBag" && buildingManager.isHasPlacedItem == true)
            {
                showMissionsManager.ShowMissionGoSleep();
            }

            else
            {
                // Debug.LogError($" Имя предмета {nameItemForBuilding} ")
            }
        }

        public void InteractBuildings()
        {
            transitionsController.StartCoroutine(transitionsController.ChangeTimeDayToNightCoroutine());
            playerInteraction.isShowDescription = false;

            if(playerInteraction.isShowDescription == false)
                DisableLayer();
        }

        public void DescriptionBuildings()
        {
            if (playerInteraction.isShowDescription == true)
                textInteraction.text = "sleep";
        }


    }
}