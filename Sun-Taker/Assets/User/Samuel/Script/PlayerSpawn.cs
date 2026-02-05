using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        if (SpawnManager.Instance != null)
        {
            transform.position = SpawnManager.Instance.GetSpawnPosition();
        }
    }
}

