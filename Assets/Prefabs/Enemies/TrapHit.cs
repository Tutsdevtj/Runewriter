using UnityEngine;

public class TrapHit : MonoBehaviour
{
    [Header("Configuração")]
    [SerializeField] private float damageAmount = 20f; // Quanto de vida tira

    private void OnTriggerEnter2D(Collider2D collision)
    {

        var targetHealth = collision.GetComponent<Entity_Health>();

        if (targetHealth != null)
        {
            // A MÁGICA ACONTECE AQUI:
            // Passamos 'transform' (o espinho) como o 'damageDealer'.
            // O seu script Entity_Health vai usar a posição desse espinho
            // para calcular a direção correta do knockback automaticamente.
            targetHealth.TakeDamage(damageAmount, transform);
        }
    }
}