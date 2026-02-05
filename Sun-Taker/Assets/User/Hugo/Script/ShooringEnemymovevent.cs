using System.Linq.Expressions;
using UnityEngine;

public class ShooringEnemymovevent : MonoBehaviour
{
    public ShootingArea1 areas;
    public GameObject player;
    Transform Player;
    public float slowMS;
    public Rigidbody2D rb;

    public bool startShooting;

    public EnemyShooting EnemyShooting;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (areas.canMove == true)
        {

            if (EnemyShooting.seePlayerLeft() == false)
            {
                float targetX = player.transform.position.x;
                float currentY = transform.position.y;

                Vector2 targetPosition = new Vector2(targetX, currentY);

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, slowMS * Time.deltaTime);
            }
            else if (EnemyShooting.seePlayerRight() == false)
            {
                float targetX = player.transform.position.x;
                float currentY = transform.position.y;

                Vector2 targetPosition = new Vector2(targetX, currentY);

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, slowMS * Time.deltaTime);
            }
            else if (EnemyShooting.seePlayerLeft() == true)
            {
                startShooting = true;
            }
            else if (EnemyShooting.seePlayerRight() == true)
            {
                startShooting = true;
            }

        }


    }
}
