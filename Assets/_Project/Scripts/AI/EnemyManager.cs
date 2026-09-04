using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyWatcherController enemyWatcher;

    bool isActiveEnemy = false;

    private void Update()
    {
        if (enemyWatcher.enemyType == EnemyType.WatcherEnemy && enemyWatcher.sleepingBagController.isChangeTimeDay == true
            && isActiveEnemy == false) 
        {
            enemyWatcher.gameObject.SetActive(true);
            isActiveEnemy = true;
        }
            
        

    }
}
