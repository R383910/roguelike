using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData playerData;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvinsible = false;
    public PlayerMovement pM;
    public BoxCollider2D col;
    public GameObject graphics;
    public bool isDead;

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
        maxHealth = playerData.health;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.R) && isDead == true)
        {
            Respawn();
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
        if (isInvinsible == false)
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
        pM.enabled = false;
        col.enabled = false;
        graphics.SetActive(false);
        isDead = true;
        Debug.LogWarning("t mort");
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        pM.enabled = true;
        col.enabled = true;
        graphics.SetActive(true);
        isDead = false;
    }
}