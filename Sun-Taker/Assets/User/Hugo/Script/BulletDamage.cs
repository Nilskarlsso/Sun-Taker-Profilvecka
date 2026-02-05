using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletDamage : MonoBehaviour
{
    PlayerHealth Phealth;
    public int damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }

}
