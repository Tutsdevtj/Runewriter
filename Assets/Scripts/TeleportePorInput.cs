using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportePorInput : MonoBehaviour
{
    [Header("Configuração")]
    public string nomeDaCena = "RuneRoom";
    
    [Header("Interface")]
    [Tooltip("Arraste aqui o Canvas ou Sprite do 'E' que deve aparecer")]
    public GameObject avisoVisual; // 👈 Onde você vai arrastar o objeto do "E"

    private bool playerPerto = false;

    private void Start()
    {
        // Garante que o aviso comece escondido
        if (avisoVisual != null)
        {
            avisoVisual.SetActive(false);
        }
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            EntrarNaSala();
        }
    }

    void EntrarNaSala()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPerto = true;
            
            // MOSTRA O "E"
            if (avisoVisual != null) avisoVisual.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPerto = false;

            // ESCONDE O "E"
            if (avisoVisual != null) avisoVisual.SetActive(false);
        }
    }
}