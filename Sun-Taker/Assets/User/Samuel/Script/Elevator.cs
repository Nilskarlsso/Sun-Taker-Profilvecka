using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform posToGo;
    [SerializeField] private ScreenFader screenFader;

    [Header("Lock Settings")]
    [SerializeField] private bool isLocked = true;

    private bool playerDetected;
    private GameObject playerGo;

    void Update()
    {
        if (isLocked)
            return;

        if (playerDetected && playerGo != null && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(screenFader.FadeOutIn(posToGo.position, playerGo.transform));
            playerDetected = false;
            playerGo = null;
        }
    }

    public void Unlock()
    {
        isLocked = false;
        Debug.Log("Teleporter unlocked");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
            playerGo = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
            playerGo = null;
        }
    }
}
