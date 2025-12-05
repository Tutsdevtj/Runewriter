using UnityEngine;

public class BonfireTrigger : MonoBehaviour
{
    public GameObject interactionUI; 

    private void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactionUI != null) interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactionUI != null) interactionUI.SetActive(false);
        }
    }
}