using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20;
    //public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack();
        }
    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    //public void EnragedAttack()
    //{
    //    Vector3 pos = transform.position;
    //    pos += transform.right * attackOffset.x;
    //    pos += transform.up * attackOffset.y;
    //
    //    Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
    //    if (colInfo != null)
    //    {
    //        colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
    //    }
    //}

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}