using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;
    public int enemyHealth;
    public GameObject enemy;
    void Start()
    {
        enemyHealth = enemyData.health;
    }

    public void Update()
    {
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void takeDamage(int _enemyHealth, int _damage)
    {
        _enemyHealth -= _damage;
    }

    public void Die()
    {
        Destroy(enemy);
    }
}
