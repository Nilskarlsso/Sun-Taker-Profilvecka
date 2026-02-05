using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    [SerializeField] int pierce = 2;
    [SerializeField] private int damage = 1;

    void Update() => transform.right = rb.linearVelocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            pierce--;
            if (pierce == 0)
                Destroy(gameObject);
        }
        if (collision.CompareTag("Target"))
        {
            Health enemy = collision.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}