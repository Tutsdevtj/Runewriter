using System.Runtime.Serialization;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    private EntityVfx vfx;
    public float damage = 10;

    [Header("Target detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    private void Awake()
    {
        vfx = GetComponent<EntityVfx>();
    }

    public void PerformAttack()
    {
        foreach(var target in GetDetectedColliders())
        {
            IDamgable damgable = target.GetComponent<IDamgable>();

            if (damgable == null)
                continue; 

            damgable.TakeDamage(damage, transform);
            vfx.CreateOnHitVFX(target.transform);
        }
    }

    protected Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position,targetCheckRadius, whatIsTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
