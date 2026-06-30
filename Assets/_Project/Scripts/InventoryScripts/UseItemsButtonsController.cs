using UnityEngine.UI;
using UnityEngine;

namespace _Project.Scripts.InventoryScripts
{
    public class UseItemsButtonsController : MonoBehaviour
    {
        // надо сделать включение кнопок для использования предметов в нужный момент

        public void ClickUseItemBtn(Toggle toggle) 
        {
            toggle.isOn = false;
        }
    }
}
