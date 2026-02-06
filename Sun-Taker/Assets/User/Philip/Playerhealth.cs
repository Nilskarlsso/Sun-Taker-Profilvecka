using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthBarSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        if (healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
        
    }

    // Update is called once per frame
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) 
            currentHealth = maxHealth;

        if (healthBarSlider != null)
            healthBarSlider.value = currentHealth;

        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        if (healthBarSlider != null)
            healthBarSlider.value = currentHealth;
    }
}
