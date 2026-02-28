using Scripts.OdinSerializerSavesAndLoads;
using UnityEngine;

public class ResetSavesKeysContext : MonoBehaviour
{
    [ContextMenu("Reset Saves Keys (Польз.)")]
    public void DeleteKeys()
    {
        PlayerPrefs.DeleteKey(OdinSerializerControllerSaveAndLoad.CountFileKey);

        PlayerPrefs.DeleteKey(CheckpointController.CanContinueGameKey);
        PlayerPrefs.DeleteKey(CheckpointController.CheckpointActiveKey);

        PlayerPrefs.DeleteKey(CheckpointManager.NonActiveCheckpointKey);

        //PlayerPrefs.DeleteKey(ShowTextLoadButtons.LoadButtonsKeys.DateTimeTextKey);
        //PlayerPrefs.DeleteKey(ShowTextLoadButtons.LoadButtonsKeys.GameTimeTextKey);
        //PlayerPrefs.DeleteKey(ShowTextLoadButtons.LoadButtonsKeys.LoadGameNameKey);

        PlayerPrefs.DeleteKey(ILoadScene.HasButtonPressKey);

        Debug.Log("Ключи СОХРАНЕНИЯ чекпоинтов УДАЛЕНЫ");
    }
}
