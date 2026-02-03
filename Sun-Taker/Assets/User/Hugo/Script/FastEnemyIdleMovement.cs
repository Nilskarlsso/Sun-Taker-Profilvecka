using UnityEngine;
using UnityEngine.WSA;

public class FastEnemyIdleMovement : MonoBehaviour
{
    public Launch launch;
    public Areas areas;
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D rb;

    Transform currentPoint;
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (areas.canMove == false)
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
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
                launch.jump = false;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
