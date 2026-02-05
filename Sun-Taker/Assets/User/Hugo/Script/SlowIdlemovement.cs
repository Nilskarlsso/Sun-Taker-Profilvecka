using JetBrains.Annotations;
using UnityEngine;

public class SlowIdlemovement : MonoBehaviour
{
    public JumpArea areas;
    public GameObject pointA;
    public GameObject pointB;
    Rigidbody2D rb;

    Transform currentPoint;
    public float speed;

    public Launch launch;

    public float downWait;
    public float upWait;
    public float downMaxWait;
    public float upMaxWait;
    public float force = 100;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upWait = upMaxWait;
        downWait = downMaxWait;
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isGrounded == false)
        {
            areas.area1.SetActive(false);
        }
        else if(isGrounded == true)
        {
            areas.area1.SetActive(true);
        }



        if(areas.canMove == false)
        {
            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointB.transform)
            {
                rb.linearVelocity = new Vector2(speed, 0);
            }
            else
            {
                rb.linearVelocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
                launch.isUp = true;
                launch.jump = false;
                downWait = downMaxWait;
                upWait = upMaxWait;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
                launch.isDown = true;
                launch.jumpDown = false;
                downWait = downMaxWait;
                upWait = upMaxWait;
            }
        }

        if (launch.jump == true)
        {
            upWait -= Time.deltaTime;
            if (upWait >= 0f)
            {
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

            }
        }
        else if(launch.jumpDown == true)
        {
            downWait -= Time.deltaTime;
            if (downWait >= 0f)
            {
                rb.AddForce(Vector2.down * force,ForceMode2D.Impulse);


            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
