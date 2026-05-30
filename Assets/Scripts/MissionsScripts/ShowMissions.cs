using UnityEngine;

namespace Scripts.MissionsScripts
{
    public class ShowMissions : MonoCache
    {
        [SerializeField] DrivingPlayer drivingPlayer;
        [SerializeField] CheckCompleteTasksNotepad checkCompleteTasksNotepad;

        [Header("Window Mission For Buy Items For Survival")]
        [SerializeField] GameObject windowMissionBuyItemsForSurvival;

        [Header("Window Mission Sit In The Car")]
        [SerializeField] GameObject windowNissionSitInCar;

        [SerializeField] GameObject panelMissions;

        public override void OnTick()
        {
            if (drivingPlayer.isInCar == false) 
                ShowMissionBuyItemsShopForSurvival();

            if (checkCompleteTasksNotepad.completeMissionItemsForSurvival == true) 
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
