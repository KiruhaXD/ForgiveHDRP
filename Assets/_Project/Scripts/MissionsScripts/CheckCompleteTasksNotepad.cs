using UnityEngine;
using UnityEngine.UI;

public class CheckCompleteTasksNotepad : MonoCache
{
    [SerializeField] Toggle[] toggleItemsForSurvival;

    //[HideInInspector]
    public bool completeMissionItemsForSurvival = false;

    public override void OnTick() 
    {
        CheckTogglesItemsForSurvival();
    }

    public void CheckTogglesItemsForSurvival() 
    {
       
    }
}
