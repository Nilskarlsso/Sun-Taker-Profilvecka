using UnityEngine;

public class Player : MonoBehaviour
{


    public float ms;
    public Rigidbody2D rb;
    Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
