using UnityEngine;

// three types enemys: attacking, following, watching

public enum EnemyType 
{
    Attacking,
    Following,
    Wathicng
}

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;
}
