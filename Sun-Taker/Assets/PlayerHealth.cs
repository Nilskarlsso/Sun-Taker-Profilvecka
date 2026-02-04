using UnityEditor.UIElements;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    public void Heal(int Amount)
    {
        currentHealth += Amount;
        if (currentHealth > maxHealth) 
            currentHealth = maxHealth;

        Debug.Log($"Player healed +{Amount}. Health: {currentHealth}/{maxHealth}");
        
    }
}
