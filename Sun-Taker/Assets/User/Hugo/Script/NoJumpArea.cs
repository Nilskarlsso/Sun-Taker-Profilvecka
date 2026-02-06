using UnityEngine;

public class NoJumpArea : MonoBehaviour
{
    public bool canMove;
    public GameObject area1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = false;
        }
    }

}
