using UnityEngine;

public class MenuSettingsInGameMenu : MonoBehaviour
{
    [SerializeField] GameObject panelDisplayMenu;
    [SerializeField] GameObject panelGraphicsMenu;
    [SerializeField] GameObject panelAudioMenu;
    [SerializeField] GameObject panelKeybindsMenu;

    public void DisplayMenuClick() 
    {
        panelDisplayMenu.SetActive(true);
        HideButtonsExceptDisplay();
    }

    public void GraphicsMenuClick() 
    {
        panelGraphicsMenu.SetActive(true);
        HideButtonsExceptGraphics();
    }

    public void AudioMenuClick() 
    {
        panelAudioMenu.SetActive(true);
        HideButtonsExceptAudio();
    }

    public void KeybindsMenuClick() 
    {
        panelKeybindsMenu.SetActive(true);
        HideButtonsExceptKeybinds();
    }

    public void HideButtonsExceptDisplay() 
    {
        panelGraphicsMenu.SetActive(false);
        panelAudioMenu.SetActive(false);
        panelKeybindsMenu.SetActive(false);
    }

    public void HideButtonsExceptGraphics() 
    {
        panelDisplayMenu.SetActive(false);
        panelAudioMenu.SetActive(false);
        panelKeybindsMenu.SetActive(false);
    }

    public void HideButtonsExceptAudio()
    {
        panelDisplayMenu.SetActive(false);
        panelGraphicsMenu.SetActive(false);
        panelKeybindsMenu.SetActive(false);
    }

    public void HideButtonsExceptKeybinds()
    {
        panelDisplayMenu.SetActive(false);
        panelGraphicsMenu.SetActive(false);
        panelAudioMenu.SetActive(false);
    }
}
