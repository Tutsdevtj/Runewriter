using UnityEngine;

public class AltarInteraction : MonoBehaviour
{
    [SerializeField] private GameObject altarPanel;
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Alterna painel
            altarPanel.SetActive(!altarPanel.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            altarPanel.SetActive(false);
        }
    }
}
