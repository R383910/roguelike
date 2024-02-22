using System;
using UnityEngine;

public class Attack : MonoBehaviour
{ //déclaration de variable
    public Collider2D colliderTrigger;
    public float reloadTimeAttack;
    private float reloadAttack;
    public EnemyHealth enemyHealth;
    public PlayerData playerData;
    private int damage;

    void Start()
    {
        reloadAttack = reloadTimeAttack;
        damage = playerData.damage;
    }

    void Update()
    {
        if (reloadAttack > 0)
        {
            reloadAttack -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D _collider)
    {
        Debug.Log("IsTriger");
        if (_collider.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.E) && reloadAttack <= 0)
        {
            Debug.Log("Attack effectué");
            enemyHealth.TakeDamage(damage);
            reloadAttack = reloadTimeAttack;
        }
    }
}
