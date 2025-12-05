using UnityEngine;

public class bonfireLogic : MonoBehaviour
{
    private bool playerNaArea;
    private Player_Health playerScript;

    [Header("Som")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip healSound;     

    void Update()
    {
        if (playerNaArea && Input.GetKeyDown(KeyCode.E))
        {
            if (audioSource != null && healSound != null)
            {
                audioSource.PlayOneShot(healSound);
            }

            if (playerScript != null)
            {
                playerScript.currentHp = 100f;
                playerScript.UpdateHealthBar(); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            playerNaArea = true;
            playerScript = other.GetComponent<Player_Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNaArea = false;
            playerScript = null; 
        }
    }
}