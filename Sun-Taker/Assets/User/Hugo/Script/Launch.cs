using UnityEngine;

public class Launch : MonoBehaviour
{
    SlowIdlemovement checker;
    public bool jump;
    public bool jumpDown;
    public bool isDown;
    public bool isUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jump = false;
        jumpDown = false;
        isDown = true;
        isUp = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slow Enemy" && jump == false && isDown == true)
        {
            jump = true;
            isDown = false;
           // Debug.Log("free jump");
        }
        else if (collision.gameObject.tag == "Slow Enemy" && jumpDown == false && isUp == true)
        {
            jumpDown = true;
            isUp = false;
           // Debug.Log("lol ez");
        }
    }
}
