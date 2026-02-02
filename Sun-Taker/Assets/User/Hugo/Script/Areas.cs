using UnityEngine;

public class Areas : MonoBehaviour
{
    public bool canMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.gameObject.tag == "Player")
        {
            canMove = true;
            Debug.Log("ig");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = false;

        Debug.Log("cool ig");
    }


}
