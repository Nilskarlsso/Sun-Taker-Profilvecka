using UnityEngine;

public class Test : MonoBehaviour
{
    public int health;

    public int maxHealth = 10;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
