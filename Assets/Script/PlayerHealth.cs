using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public SpriteRenderer graphics;
    //public HealthBar healthBar;

    public AudioClip hitSound;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        //healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

    }

    public void Die()
    {
        Debug.LogWarning("t mort");
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        //healthBar.SetHealth(currentHealth);
    }
}