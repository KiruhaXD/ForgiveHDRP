using UnityEngine.UI;
using UnityEngine;

namespace _Project.Scripts.InventoryScripts
{
    // скрипт отвечающий за использование объектов из блокнота по кнопке (USE)
    public class UseItemsButtonsController : MonoBehaviour
    {
        // надо сделать включение кнопок для использования предметов в нужный момент

        [SerializeField] GameObject currentPlacedObject;

        public void ClickUseItemBtn(Toggle toggle) 
        {
            currentPlacedObject.SetActive(true);
            toggle.isOn = false;
            this.gameObject.SetActive(false);
        }
    }
}
