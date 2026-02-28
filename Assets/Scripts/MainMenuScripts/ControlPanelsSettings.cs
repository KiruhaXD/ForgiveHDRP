using TMPro;
using UnityEngine;

public class ControlPanelsSettings : MonoBehaviour
{
    [Header("Panels Settings")]
    public GameObject[] panelsSettings;

    public void PanelsSettings(TMP_Text currentText) 
    {
        for (int i = 0; i < panelsSettings.Length; i++)
        {
            panelsSettings[i].SetActive(false);

            switch (currentText.name)
            {
                case "Text (TMP) DISPLAY":
                    panelsSettings[0].SetActive(true);
                    break;

                case "Text (TMP) GRAPHICS":
                    panelsSettings[1].SetActive(true);
                    break;

                case "Text (TMP) AUDIO":
                    panelsSettings[2].SetActive(true);
                    break;

                case "Text (TMP) CONTROLS":
                    panelsSettings[3].SetActive(true);
                    break;
            }
        }
    }
}
