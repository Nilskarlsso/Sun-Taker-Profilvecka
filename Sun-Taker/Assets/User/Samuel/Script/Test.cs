using UnityEngine;

public class Test : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAttack")
        {
            Destroy(gameObject);
        }
    }
}
