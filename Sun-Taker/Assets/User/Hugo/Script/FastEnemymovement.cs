using UnityEngine;

public class FastEnemymovement : MonoBehaviour
{
    public Areas areas;
    public GameObject player;
    Transform Player;
    public float fastMS;
    public Rigidbody2D rb;

    private float distance;
    public float aggroDistance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (areas.canMove == true)
        {
            float targetX = player.transform.position.x;
            float currentY = transform.position.y;

            Vector2 targetPosition = new Vector2(targetX, currentY);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, fastMS * Time.deltaTime);
        }




    }
}
