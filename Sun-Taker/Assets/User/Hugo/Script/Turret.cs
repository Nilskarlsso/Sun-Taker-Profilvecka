using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPos;

    public float timer;
    public float fireRate = 1;
    public float range = 10;

    public GameObject player;

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

        }


    }

    void shoot()
    {
        Instantiate(bullet, shootingPos.position, Quaternion.identity);
    }
}
