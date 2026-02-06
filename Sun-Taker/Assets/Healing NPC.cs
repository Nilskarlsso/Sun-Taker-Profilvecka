using UnityEngine;

public class HealingNPC : MonoBehaviour
{
    public int healAmount = 25;
    public float healCooldown = 3f;

    private bool playerInRange = false;
    private PlayerHealth playerHealth;
    private float lastHealTime = -Mathf.Infinity; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time - lastHealTime >= healCooldown)
            {
                playerHealth.Heal(healAmount);
                lastHealTime = Time.time;
                Debug.Log("Healed by NPC!");
            }
            else
            {
                Debug.Log("Wait a bit before healing again!");
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerHealth = collision.GetComponent<PlayerHealth>();
            Debug.Log("Press E to get healed!");
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            Debug.Log("Press E to heal");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            playerHealth = null;
        }
        
    }
}
