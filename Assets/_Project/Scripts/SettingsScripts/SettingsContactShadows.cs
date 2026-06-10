using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SettingsContactShadows : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile volumeProfile;

    [SerializeField] TMP_Text contactShadowsLabel;
    [SerializeField] TMP_Dropdown contactShadowsDropdown;

    internal bool isHasEditSettingsContactShadows = false;

    public void ContactShadows(int currentContactShadows) 
    {
        volumeProfile = volume.sharedProfile;

        if (volumeProfile.TryGet<ContactShadows>(out var contactShadows)) 
        {
            switch (currentContactShadows) 
            {
                case 0:
                    contactShadows.active = false;

                    contactShadowsLabel.text = "Contact Shadows*";
                    isHasEditSettingsContactShadows = true;
                    break;

                case 1:
                    ChangeContactShadows(contactShadows);
                    contactShadows.quality.value = 0;
                    break;

                case 2:
                    ChangeContactShadows(contactShadows);
                    contactShadows.quality.value = 1;
                    break;

                case 3:
                    ChangeContactShadows(contactShadows);
                    contactShadows.quality.value = 2;
                    break;
            }
        }
    }

    public void ChangeContactShadows(ContactShadows contactShadows) 
    {
        contactShadows.active = true;

        contactShadowsLabel.text = "Contact Shadows*";
        isHasEditSettingsContactShadows = true;
    }

    public void SaveContactShadows() 
    {
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.ContactShadowsKeys, contactShadowsDropdown.value);

        RemoveSpecialSignContactShadows();
    }

    public void LoadContactShadows() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ContactShadowsKeys))
            contactShadowsDropdown.value = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.ContactShadowsKeys);

        RemoveSpecialSignContactShadows();
    }

    public void RemoveSpecialSignContactShadows() 
    {
        contactShadowsLabel.text = "Contact Shadows";
        isHasEditSettingsContactShadows = false;
    }
}
