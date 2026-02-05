using UnityEngine;

public class ShootingArea1 : MonoBehaviour
{
    public bool canMove;
    public GameObject area1;
    public ShooringEnemymovevent shootingEnemyMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canMove = true;
            shootingEnemyMovement.startShooting = true;
            Debug.Log("fuck yeah");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = false;
            shootingEnemyMovement.startShooting = false;
        }
    }

}
