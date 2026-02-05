using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 5;

    public EnemyHealth enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(enemyHealth == null)
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
