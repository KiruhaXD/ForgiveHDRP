using _Project.Scripts.OdinSerializerSavesAndLoads;
using UnityEngine;

namespace _Project.Scripts.CheckpointsScripts
{

    public class CheckpointController : MonoBehaviour
    {
        SaveDataPlayer saveDataPlayer = new SaveDataPlayer();

        public const string CheckpointActiveKey = "active_checkpoint";

        public static int checkpointActive = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out OdinSerializerControllerSaveAndLoad odinSerializerControllerSaveAndLoad))
            {
                odinSerializerControllerSaveAndLoad.SaveData(saveDataPlayer);

                gameObject.SetActive(false);
                checkpointActive = 0;

                PlayerPrefs.SetInt(CheckpointActiveKey, checkpointActive);
            }
        }
    }
}