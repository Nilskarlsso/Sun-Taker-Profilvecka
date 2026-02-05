using UnityEngine;

public class PowerArmorBoss : MonoBehaviour
{
    [Header("Refrence")]
    public Animator anim;
    public bool isAttacking = false;

    private enum BossState { Idle, Charge, Jump }
    private BossState currentState = BossState.Idle;

    [Header("State Timer")]
    public float idleDuration = 2f;
    private float stateTimer;

    [Header("Basic Movment and Stuff")]
    private bool facingRight;
    private GameObject bossRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bossRb = GetComponent<GameObject>();

        stateTimer = idleDuration;

        if (anim == null)
        {
            Debug.LogError("Anim not found");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // dont change the state if attacking
        if (isAttacking) return;
        
        // timer countdown
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            //switch to next state
            switch (currentState)
            {
                case BossState.Idle:
                    ChooseAttack();
                    break;
                case BossState.Charge:

                case BossState.Jump:
                    EnterStateIdle();
                    break;
            }
        }
    }

    void ChooseAttack()
    {
        // pick randomly between charge or jump
        bool pickCharge = Random.value < 0.5f;

        if (pickCharge)
        {
            currentState = BossState.Charge;
            TriggerCharge();
        }
        else
        {
            currentState = BossState.Jump;
            TriggerJumpSlam();
        }
    }

    void EnterStateIdle()
    {
        currentState = BossState.Idle;
        stateTimer = idleDuration;
    }

    public void TriggerCharge()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        anim.SetTrigger("charge");
        if (facingRight)
        {

        }
    }

    public void TriggerJumpSlam()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        anim.SetTrigger("jump");
    }

    public void EndAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", false);
        stateTimer = 0f; // sligt delay befor returning to idle
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
