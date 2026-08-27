using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.InventoryScripts
{
    // скрипт отвечающий за проверку выполненных задач(например игрок подобрал нужное кол-во предметов опеределенного типа - для выживания)
    public class CheckCompleteTasksNotepad : MonoCache
    {
        [SerializeField] Toggle[] toggleItemsForSurvival;

        [HideInInspector]
        public bool completeMissionItemsForSurvival = false;

        int maxAddItemsSurvival = 6;

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
