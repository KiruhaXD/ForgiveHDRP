using UnityEngine;

namespace _Project.Scripts.InventoryScripts
{
    public static class CounterAddItemsController
    {
        [HideInInspector]
        public static int countAddSurvivalItems = 0;

        public static void CounterAddSurvivalItems(RaycastHit hit)
        {
            if (hit.collider.tag == "ItemsInteractionForSurvival")
                countAddSurvivalItems++;
        }
    }
}