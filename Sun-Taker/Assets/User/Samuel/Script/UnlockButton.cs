using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    [SerializeField] private Elevator elevator;

    private bool playerInRange;
    private bool used;

    void Update()
    {
        if (playerInRange && !used && Input.GetKeyDown(KeyCode.E))
        {
            elevator.ButtonPressed();
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
