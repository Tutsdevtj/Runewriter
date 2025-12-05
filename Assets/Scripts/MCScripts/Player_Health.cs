using System.Collections;
using UnityEngine;

// Herda de Entity_Health em vez de MonoBehaviour
public class Player_Health : Entity_Health 
{
    [Header("Player Invulnerability")]
    [SerializeField] private float iFrameDuration = 1f;
    [SerializeField] private float flashDuration = 0.1f;
    
    private bool isInvulnerable;
    private SpriteRenderer sr;

    protected override void Awake()
    {
        base.Awake(); 
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public override void TakeDamage(float damage, Transform damageDealer)
    {
      
        if (isInvulnerable) return;

        
        base.TakeDamage(damage, damageDealer);

        if (!isDead) 
        {
            StartCoroutine(InvulnerabilityRoutine());
        }
    }

    private IEnumerator InvulnerabilityRoutine()
    {
        isInvulnerable = true;
        
        float elapsed = 0f;
        while (elapsed < iFrameDuration)
        {
            if(sr != null) sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(flashDuration);
            elapsed += flashDuration;
        }
        if(sr != null) sr.enabled = true;

        isInvulnerable = false;
    }
}