using System;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{
    public BoxCollider2D colliderTrigger;
    public float reloadTimeAttack;
    private float reloadAttack;
    public EnemyHealth enemyHealth;
    public PlayerData playerData;
    private int damage;

    public void Start()
    {
        reloadAttack = reloadTimeAttack;
        damage = playerData.damage;
    }

    public void Update()
    {
        if (reloadAttack > 0)
        {
            reloadAttack -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(BoxCollider2D _collider)
    {
        if (_collider.CompareTag("Ennemy") && Input.GetKeyDown(KeyCode.E) && reloadAttack == 0)
        {
            int _enemyHealth = enemyHealth.enemyHealth;
            enemyHealth.takeDamage(_enemyHealth, damage);
        }
    }
}
