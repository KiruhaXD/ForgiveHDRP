using UnityEngine;

namespace Scripts.MissionsScripts
{
    public class ShowMissions : MonoCache
    {
        [SerializeField] DrivingPlayer drivingPlayer;

        [Header("Window Mission For Buy Items For Survival")]
        [SerializeField] GameObject windowMissionBuyItemsForSurvival;

        [SerializeField] GameObject panelMissions;

        public override void OnTick()
        {
            if (drivingPlayer.isInCar == false) 
                ShowMissionBuyItemsShopForSurvival();
            
        }

        // должна быть подсказка для открытия блокнота
        public void ShowMissionBuyItemsShopForSurvival() 
        {
            panelMissions.SetActive(true);
            windowMissionBuyItemsForSurvival.SetActive(true);
        } 
        



    }
}
