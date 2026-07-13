using _Project.Scripts.CheckpointsScripts;
using UnityEngine;

namespace _Project.Scripts.OdinSerializerSavesAndLoads
{
    public class ResetSavesKeysContext : MonoBehaviour
    {
        [ContextMenu("Reset Saves Keys (Польз.)")]
        public void DeleteKeys()
        {
            PlayerPrefs.DeleteKey(CheckpointController.CheckpointActiveKey);
            PlayerPrefs.DeleteKey(CheckpointManager.CountTriggerCheckpointKey);

            Debug.Log("Ключи СОХРАНЕНИЯ чекпоинтов УДАЛЕНЫ");
        }
    }
}
