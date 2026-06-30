using _Project.Scripts.DialogueSystem.DialogueWithSalerScripts;
using _Project.Scripts.InventoryScripts;
using UnityEngine;

namespace _Project.Scripts.MissionsScripts
{
    public class ShowMissions : MonoCache
    {
        [Header("References From Other Classes")]
        [SerializeField] DrivingPlayer drivingPlayer;
        [SerializeField] CheckCompleteTasksNotepad checkCompleteTasksNotepad;
        [SerializeField] DialogueWithSaler dialogueWithSaler;

        [Header("Window Mission For Buy Items For Survival")]
        [SerializeField] GameObject windowMissionBuyItemsForSurvival;

        [Header("Window Mission Sit In The Car")]
        [SerializeField] GameObject windowNissionSitInCar;

        [SerializeField] GameObject panelMissions;

        public override void OnTick()
        {
            if (drivingPlayer.isInCar == false) 
                ShowMissionBuyItemsShopForSurvival();

            if (checkCompleteTasksNotepad.completeMissionItemsForSurvival == true && 
                dialogueWithSaler.hasBoughtItemsInShop == true) 
            {
                ShowMissionSitInCar();
            }
        }

        // должна быть подсказка для открытия блокнота


        public void ShowMissionBuyItemsShopForSurvival() 
        {
            panelMissions.SetActive(true);
            windowMissionBuyItemsForSurvival.SetActive(true);
        }

        public void ShowMissionSitInCar() 
        {
            windowMissionBuyItemsForSurvival.SetActive(false);

            windowNissionSitInCar.SetActive(true);
        }
        



    }
}
