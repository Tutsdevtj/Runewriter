using UnityEngine;

public class AltarInteraction : MonoBehaviour
{
    [SerializeField] private GameObject altarPanel;
    private bool isPlayerNearby = false;

    [SerializeField] public Player player;

    void Update()
    {
        if (!altarPanel) return; // painel destruído → ignora

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            bool willOpen = !altarPanel.activeSelf;
            altarPanel.SetActive(willOpen);

            if (willOpen)
                player.input.Disable();
            else
                player.input.Enable();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (altarPanel != null)
                altarPanel.SetActive(false);

            player.input.Enable();
        }
    }
}
