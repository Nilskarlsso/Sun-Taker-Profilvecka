using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int damage = 2;

    public Test enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (enemyHealth == null)
                enemyHealth = collision.gameObject.GetComponent<Test>();
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
