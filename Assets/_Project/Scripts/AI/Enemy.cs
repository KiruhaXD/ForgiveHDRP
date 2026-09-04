using UnityEngine;

enum EnemyType 
{
    Default,
    WatcherEnemy,
    AttackEnemy
}

public class Enemy : MonoBehaviour
{
    [SerializeField] internal EnemyType enemyType = EnemyType.Default;

    [SerializeField] Animator animatorEnemy;
}
