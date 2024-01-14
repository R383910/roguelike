using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvisible = false;

    public SpriteRenderer graphics;

    public AudioClip hitSound;

    public static PlayerHealth instance;
    public HealthBar healthBar;

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
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
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
        
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isInvisible == false)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
                currentHealth = 0;
                return;
            }
        }
        
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        healthBar.SetHealth(0);
        Debug.LogWarning("t mort");
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}