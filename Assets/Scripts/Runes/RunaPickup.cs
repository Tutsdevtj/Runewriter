using UnityEngine;

public class RunaPickup : MonoBehaviour
{
    public RunaTipo tipo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameState.Instance == null)
            {
                Debug.LogError("ERRO: O objeto GameState não está na cena!");
                return;
            }

            if (tipo == RunaTipo.Verde)
                GameState.Instance.runaVerde++;

            if (tipo == RunaTipo.Azul)
                GameState.Instance.runaAzul++;

            if (UI_RuneColector.Instance != null)
            {
                UI_RuneColector.Instance.AtualizarUI();
            }
            else
            {
                Debug.LogWarning("Avisando: UI_RuneColector não foi encontrado, mas a runa foi pega.");
            }

            Destroy(gameObject);
        }
    }
}