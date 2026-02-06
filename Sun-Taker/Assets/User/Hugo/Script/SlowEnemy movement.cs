using UnityEngine;

public class SlowEnemymovement : MonoBehaviour
{
    public JumpArea areas;
    public GameObject player;
    Transform Player;
    public float slowMS;
    public Rigidbody2D rb;
    
    public EnemyAttack enemyAttack;

    void Start()
    {
        GetComponentInChildren<EnemyAttack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (areas.canMove == true)
        {
            float targetX = player.transform.position.x;
            float currentY = transform.position.y;

            Vector2 targetPosition = new Vector2(targetX, currentY);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, slowMS * Time.deltaTime);
        }
        

    }
}
