using UnityEngine;

public class TrapHit : MonoBehaviour
{
    [Header("Configuração")]
    [SerializeField] private float damageAmount = 20f;

    // Não precisamos mais da variável "pontoDeRetorno" aqui!

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetHealth = collision.GetComponent<Entity_Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damageAmount, transform);

            if (collision.CompareTag("Player") && GameState.Instance != null)
            {
                collision.transform.position = GameState.Instance.ultimoCheckpoint;

                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                if (rb != null) rb.linearVelocity = Vector2.zero;
            }
        }
    }
}