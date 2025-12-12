using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameState.Instance != null)
            {
                GameState.Instance.ultimoCheckpoint = transform.position;
                Debug.Log("Checkpoint salvo!");
            }
        }
    }
}