using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        
    }

    // Update is called once per frame
    public void SetHealth(float health)
    {
        slider.value = health;
        
    }
}
