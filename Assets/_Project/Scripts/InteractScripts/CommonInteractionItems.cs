using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommonInteractionItems : MonoBehaviour
{
    protected void CommonInteractItem(Toggle toggle) 
    {
        toggle.isOn = true;
        this.gameObject.SetActive(false);
    }

    protected void CommonDescriptionItem(TMP_Text tmpText, string text) => tmpText.text = text;

    
}
