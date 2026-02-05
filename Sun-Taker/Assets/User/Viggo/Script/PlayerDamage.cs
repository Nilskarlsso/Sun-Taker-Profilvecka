using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 5;

    public Test enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(enemyHealth == null)
            enemyHealth = collision.gameObject.GetComponent<Test>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
