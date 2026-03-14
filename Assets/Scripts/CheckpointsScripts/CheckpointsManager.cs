using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public const string NonActiveCheckpointKey = "non_active_checkpoint";
    //public const string CheckpointListKey = "ckecpoints_list";
    public const string CheckpointsListCountKey = "ckecpoints_list_count";

    [SerializeField] GameObject[] checkpointsObjects;

    int isNonActivateCheckpoint = 0;

    public List<int> listNonActiveCheckpoint; // использую списки чтоб сохранять все скрытые чекпоинты, например не только чекпоинт (под индексом 0),
    // но и под индексом (0 и 1)
    public int checkpointsListCount = 0;


    private void Awake()
    {
        if (PlayerPrefs.HasKey(CheckpointController.CheckpointActiveKey) && PlayerPrefs.HasKey(NonActiveCheckpointKey) 
            /*&& PlayerPrefs.HasKey(CheckpointListKey)*/ && PlayerPrefs.HasKey(CheckpointsListCountKey)) 
        {
            CheckpointController.checkpointActive = PlayerPrefs.GetInt(CheckpointController.CheckpointActiveKey);

            checkpointsListCount = PlayerPrefs.GetInt(CheckpointsListCountKey);

            if (CheckpointController.checkpointActive == 0) 
            {
                Debug.Log("Проверка...");

                int checkpoint = 0;

                for (int i = checkpoint; i < checkpointsListCount; i++)
                {
                    Debug.Log("Проходимся по циклу...");

                    i = PlayerPrefs.GetInt(NonActiveCheckpointKey);
                    checkpointsObjects[i].SetActive(false);

                    Debug.Log("Чекпоинт под индексом: " + i + " ВЫКЛЮЧИЛСЯ");
                }

                CheckpointController.checkpointActive = 1;
            }
        }
    }

    private void Update()
    {
        if (CheckpointController.checkpointActive == 0) // if checkpoint NON active
        {
            listNonActiveCheckpoint.Add(isNonActivateCheckpoint);

            isNonActivateCheckpoint++;

            checkpointsObjects[isNonActivateCheckpoint].SetActive(true);

            for (int i = 0; i < listNonActiveCheckpoint.Count; i++)
            {
                PlayerPrefs.SetInt(NonActiveCheckpointKey, listNonActiveCheckpoint[i]);
                Debug.Log("Чекпоинт под индексом: " + listNonActiveCheckpoint[i] + " стал НЕ АКТИВНЫМ и СОХРАНИЛСЯ");
            }

            //PlayerPrefs.SetInt(CheckpointListKey, listNonActiveCheckpoint.Count);

            CheckpointController.checkpointActive = 1;

        }
    }
}
