using Scripts.OdinSerializerSavesAndLoads;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public const string CanContinueGameKey = "can_continue_game";
    public const string CheckpointActiveKey = "active_checkpoint";

    [SerializeField] SaveDataInfo saveDataInfo;
    [SerializeField] CheckpointManager checkpointManager;

    public static int continueGame = 0; // 1 (isCanContinueGame) - true, 0 (isCanContinueGame) - false

    public static int checkpointActive = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out OdinSerializerControllerSaveAndLoad odinSerializerControllerSaveAndLoad))
        {
            this.gameObject.SetActive(false);
            checkpointActive = 0;  // чекпоинты не скрываются когда загружается сцена (почему-то не сохраняются данные о том что чекпоинты скрыты)

            PlayerPrefs.SetInt(CheckpointActiveKey, checkpointActive);

            odinSerializerControllerSaveAndLoad.SaveData();

            checkpointManager.checkpointsListCount++;
            PlayerPrefs.SetInt(CheckpointManager.CheckpointsListCountKey, checkpointManager.checkpointsListCount);

            saveDataInfo.InfoActive();

            saveDataInfo.InfoNonActive();

            continueGame = 1;
            PlayerPrefs.SetInt(CanContinueGameKey, continueGame);


        }
    }
}
