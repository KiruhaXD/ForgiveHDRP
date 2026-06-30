using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.InventoryScripts
{
    public class CheckCompleteTasksNotepad : MonoCache
    {
        [SerializeField] Toggle[] toggleItemsForSurvival;

        [HideInInspector]
        public bool completeMissionItemsForSurvival = false;

        int maxAddItemsSurvival = 7;

        public override void OnTick()
        {
            CheckTogglesItemsForSurvival();
        }

        public void CheckTogglesItemsForSurvival()
        {
            if (CounterAddItemsController.countAddSurvivalItems == maxAddItemsSurvival)
                completeMissionItemsForSurvival = true;
            
        }
    }
}
