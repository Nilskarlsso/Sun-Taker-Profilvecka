using UnityEngine;

public class PowerarmorBossAnim : MonoBehaviour
{
    private PowerArmorBoss armorBoss;

    private void Awake()
    {
        armorBoss = GetComponentInParent<PowerArmorBoss>();
    }
    
    public void EndAttack()
    {
        if (armorBoss != null)
        {
            armorBoss.EndAttack();
        }
        else
        {
            Debug.LogError("No ArmorBoss found on Parent.");
        }
    }
}
