using UnityEngine;

public class Launch : MonoBehaviour
{
    public bool jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slow Enemy")
        {
            jump = true;
            Debug.Log("free jump");
        }
    }
}
