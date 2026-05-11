using UnityEngine;
using UnityEngine.UI;

public class CheckCompleteTasksNotepad : MonoBehaviour
{
    [SerializeField] Toggle[] toggleItemsForSurvival;

    //bool 

    public void CheckTogglesItemsForSurvival() 
    {
        for (int i = 0; i < toggleItemsForSurvival.Length; i++) 
        {
            //if (toggleItemsForSurvival[i].isOn == true)

        }
    }
}
