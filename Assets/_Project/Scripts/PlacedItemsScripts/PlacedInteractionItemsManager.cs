using _Project.Scripts.InteractScripts;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.PlacedItemsScripts
{

    public class PlacedInteractionItemsManager : MonoBehaviour
    {
        [SerializeField] protected PlayerInteraction playerInteraction;

        [SerializeField] protected GameObject currentObject;

        [SerializeField] protected TMP_Text textInteraction;

        [SerializeField] protected BuildingManager buildingManager;

        public void DisableLayer()
        {
            if (currentObject.layer == LayerMask.NameToLayer("Interaction"))
                currentObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}