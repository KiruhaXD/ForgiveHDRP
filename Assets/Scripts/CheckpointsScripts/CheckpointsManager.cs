using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public const string NonActiveCheckpointKey = "non_active_checkpoint";

    [SerializeField] GameObject[] checkpointsObjects;

    int isNonActivateCheckpoint = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(CheckpointController.CheckpointActiveKey)) 
        {
            CheckpointController.checkpointActive = PlayerPrefs.GetInt(CheckpointController.CheckpointActiveKey);

            if (CheckpointController.checkpointActive == 0)
                checkpointsObjects[isNonActivateCheckpoint].SetActive(false);

            Debug.Log(isNonActivateCheckpoint);
        }
    }

    private void Update()
    {
        if (CheckpointController.checkpointActive == 0) // if checkpoint NON active
        {
            isNonActivateCheckpoint++;

            checkpointsObjects[isNonActivateCheckpoint].SetActive(true);

            CheckpointController.checkpointActive = 1;
        }
    }
}
