using System;
using TMPro;
using UnityEngine;

// Этот скрипт не используется!!!
/*public class ShowTextLoadButtons : MonoBehaviour
{
    public struct LoadButtonsKeys 
    {
        public const string DateTimeTextKey = "date_time";
        public const string GameTimeTextKey = "game_time";
        public const string LoadGameNameKey = "load_game_name";
    }

    [SerializeField] TMP_Text dateTime, gameTime, loadGameName;

    public void ShowTextButton(int countFile)
    {
        dateTime.text = DateTime.Now.ToString();
        loadGameName.text = "Autosave_" + countFile.ToString();
    }

    public void SaveTextForLoadButtons() 
    {
        PlayerPrefs.SetString(LoadButtonsKeys.DateTimeTextKey, dateTime.text);
        PlayerPrefs.SetString(LoadButtonsKeys.GameTimeTextKey, gameTime.text);
        PlayerPrefs.SetString(LoadButtonsKeys.LoadGameNameKey, loadGameName.text);
    }

    public void LoadTextForLoadButtons() 
    {
        if (PlayerPrefs.HasKey(LoadButtonsKeys.DateTimeTextKey)
            && PlayerPrefs.HasKey(LoadButtonsKeys.GameTimeTextKey) && PlayerPrefs.HasKey(LoadButtonsKeys.LoadGameNameKey)) 
        {
            dateTime.text = PlayerPrefs.GetString(LoadButtonsKeys.DateTimeTextKey);
            gameTime.text = PlayerPrefs.GetString(LoadButtonsKeys.GameTimeTextKey);
            loadGameName.text = PlayerPrefs.GetString(LoadButtonsKeys.LoadGameNameKey);
        }
    }
}*/
