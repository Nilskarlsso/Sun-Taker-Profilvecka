using System.Collections;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject Gate;
    public GameObject Boss;
    public float delay = 2f;

    private bool triggerd = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!triggerd && collision.CompareTag("Player"))
        {
            triggerd = true;
            if(Gate != null) Gate.SetActive(true);
            StartCoroutine(StartBoss());
        }
    }

    private IEnumerator StartBoss()
    {
        yield return new WaitForSeconds(delay);
        Boss.SetActive(true);
    }
}
