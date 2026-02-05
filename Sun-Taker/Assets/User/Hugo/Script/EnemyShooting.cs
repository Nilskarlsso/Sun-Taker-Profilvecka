using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPos;

    public float timer;
    public float fireRate = 1;

    public GameObject player;
    public Transform Player;

    public ShooringEnemymovevent shooringEnemymovevent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.right);
        Debug.DrawRay(transform.position, Vector2.left);

        if(shooringEnemymovevent.startShooting == true)
        {
            if (seePlayerLeft() == true)
            {
                timer += Time.deltaTime;
                if (timer > fireRate)
                {
                    timer = 0;
                    shoot();
                }
            }
        }




    }

    public bool seePlayerRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 2f);
        
    }
    public bool seePlayerLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, 2f);
    }

    void shoot()
    {
        Instantiate(bullet, shootingPos.position, Quaternion.identity);
    }
}
