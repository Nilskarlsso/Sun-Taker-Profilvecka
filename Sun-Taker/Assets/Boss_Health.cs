using UnityEngine;

public class Health1 : MonoBehaviour
{
    [SerializeField] public float maxHP = 100;
    [SerializeField] public float currentHP = 100;

    

    // Call this when the object takes damage
    public void TakeDamage1(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die1();
        }
    }

    // Optional: heal the object
    public void Heal(int amount)
    {
        currentHP += amount;

        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    void Die1()
    {
        Debug.Log(gameObject.name + " died!");
        Destroy(gameObject);
    }
}
