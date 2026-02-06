using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Timeline;

public class BulletDamage : MonoBehaviour
{
    public int attackDamage = 20;
    public LayerMask attackMask;

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
            Attack();
        }


    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right;
        pos += transform.up;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

}
