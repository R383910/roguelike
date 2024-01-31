using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;
    private int currentHealth;
    public GameObject enemy;

    void Start()
    {
        currentHealth = enemyData.health;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("damage");
        currentHealth -= damage;
    }

    void Die()
    {
        Debug.Log("mort");
        Destroy(enemy);
    }
}