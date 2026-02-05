using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPos;

    public float timer;
    public float fireRate = 1;
    public float range = 10;

    public GameObject player;
    public Transform Player;
    public float rotateSpeed = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {


        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < range)
        {
            timer += Time.deltaTime;

            if (timer > fireRate)
            {
                timer = 0;
                shoot();
            }

            Vector2 dir = Player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0, 0, angle + 270);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);

        }


    }

    void shoot()
    {
        Instantiate(bullet, shootingPos.position, Quaternion.identity);
    }
}
