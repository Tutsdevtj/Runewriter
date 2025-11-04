using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MC_Running : MonoBehaviour
{
    [Tooltip("Velocidade de movimento do jogador")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    
    // Agora armazena apenas o input horizontal (-1, 0, ou 1)
    private float moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Chamado pelo 'Player Input' (Send Messages) quando a ação 'Move' é ativada.
    /// </summary>
    public void OnMove(InputValue value)
    {
        // Obtém o Vector2 do input...
        Vector2 inputVector = value.Get<Vector2>();
        
        // ...mas armazena apenas o componente horizontal (X).
        // O input de W/S (componente Y) é ignorado.
        moveDirection = inputVector.x;
    }

    private void FixedUpdate()
    {
        // Aplica a velocidade no eixo X, mas preserva a velocidade 
        // atual do eixo Y (gravidade ou pulo).
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }
}