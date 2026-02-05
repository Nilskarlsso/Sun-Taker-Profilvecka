using UnityEngine;

public class JumpArea : MonoBehaviour
{
    public bool canMove;
    public GameObject jumpcolliders;
    public GameObject area1;
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
            jumpcolliders.SetActive(false);
            canMove = true;
            //Debug.Log("ig");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canMove = false;
            jumpcolliders.SetActive(true);
        }

        //Debug.Log("cool ig");
    }


}
