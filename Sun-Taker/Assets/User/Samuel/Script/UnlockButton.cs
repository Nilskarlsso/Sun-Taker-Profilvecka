using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
    [SerializeField] private bool oneTimeUse = true;

    private bool playerInRange;
    private bool used;

    void Update()
    {
        if (playerInRange && !used && Input.GetKeyDown(KeyCode.E))
        {
            elevator.Unlock();

            if (oneTimeUse)
                used = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = false;
    }
}
