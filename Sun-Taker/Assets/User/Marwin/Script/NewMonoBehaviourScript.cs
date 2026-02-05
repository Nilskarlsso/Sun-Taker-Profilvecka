using System.Collections;
using UnityEngine;

public class RadianceBoss : MonoBehaviour
{
    [Header("Stats")]
    public int PlayerHealth = 300;
    public int currentHealth;

    [Header("Phase Thresholds")]
    [Range(0f, 1f)] public float phaseTwoThreshold = 0.6f;
    [Range(0f, 1f)] public float enragedThreshold = 0.25f;

    [Header("Prefabs")]
    public GameObject swordPrefab;
    public GameObject lightOrbPrefab;
    public GameObject beamPrefab;

    [Header("Attack Settings")] 
    public float attackCooldown = 2f;
    public float swordRainCount = 8;
    public float arenaWidth = 14f;
    public float arenaHeight = 8f;

    private bool isAttacking;
    private int currentPhase = 1;

    void Start()
    {
        currentHealth = PlayerHealth;
        
    }

    

   

   

    IEnumerator SwordRain()
    {
        for (int i = 0; i < swordRainCount; i++)
        {
            Vector2 spawnPos = new Vector2(
                Random.Range(-arenaWidth, arenaWidth),
                arenaHeight
            );

            Instantiate(swordPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator LightOrbs()
    {
        int orbCount = currentPhase == 3 ? 10 : 6;

        for (int i = 0; i < orbCount; i++)
        {
            Vector2 spawnPos = transform.position;
            Instantiate(lightOrbPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator EnragedCombo()
    {
        yield return SwordRain();
        yield return new WaitForSeconds(0.5f);
        yield return LightOrbs();
        yield return new WaitForSeconds(0.5f);
        FireBeam();
    }

    void FireBeam()
    {
        Instantiate(beamPrefab, transform.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    void Die()
    {
        StopAllCoroutines();
        Debug.Log("Radiance Defeated");
        Destroy(gameObject);
    }
}