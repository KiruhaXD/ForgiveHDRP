using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsInMainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text currentText;
    [SerializeField] Image currentImage;

    [SerializeField] ControlPanelsSettings controlPanelsSettings;

    private void OnMouseDown() => controlPanelsSettings.PanelsSettings(currentText);
    
    private void OnMouseEnter()
    {
        transform.DOScale(new Vector3(13, 13, 13), 0.2f);
    }

    private void OnMouseExit()
    {
        transform.DOScale(new Vector3(14, 14, 14), 0.2f);
    }

}
