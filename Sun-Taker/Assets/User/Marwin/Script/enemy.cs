using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Target")]
    public Transform player;
    public float detectionRange = 10f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootCooldown = 1.5f;
    public float bulletSpeed = 10f;

    [Header("Facing")]
    public bool flipSprite = true;

    private float shootTimer;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            FacePlayer();
            ShootAtPlayer();
        }
    }

    void FacePlayer()
    {
        if (!flipSprite || sr == null)
            return;

        sr.flipX = player.position.x < transform.position.x;
    }

    void ShootAtPlayer()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer > 0)
            return;

        shootTimer = shootCooldown;

        Vector2 direction = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
