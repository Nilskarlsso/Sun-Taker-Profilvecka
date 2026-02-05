using UnityEngine;

public class GunCon : MonoBehaviour
{
    [SerializeField] private Animator gunAnim;
    [SerializeField] private Transform gun;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool autoFire = true;

    [Header("Auto Aim")]
    [SerializeField] private float autoAimRange = 10f;
    [SerializeField] private string enemyTag = "Player";

    [Header("Weapon Settings")]
    [SerializeField] private float pistolCooldown = 1f;

    private float nextFireTime = 0f;
    private float currentCooldown;

    Vector3 direction;

    void Start()
    {
        currentCooldown = pistolCooldown; // start with pistol
    }

    void Update()
    {
        HandleWeaponSwitch();

        Transform target = FindClosestEnemy();
        if (target == null) return;

        direction = target.position - gun.position;

        HandleShooting();
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentCooldown = pistolCooldown;
        }
    }

    void HandleShooting()
    {
        if (Time.time < nextFireTime) return;

        if (autoFire == true)
        {
            Shoot(direction);
            nextFireTime = Time.time + currentCooldown;
        }
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        Transform closest = null;
        float minDistance = autoAimRange;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(gun.position, enemy.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = enemy.transform;
            }
        }

        return closest;
    }

    public void Shoot(Vector3 direction)
    {
        gunAnim.SetTrigger("Shoot");

        GameObject newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * bulletSpeed;

        Destroy(newBullet, 7);
    }
}