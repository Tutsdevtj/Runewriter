using UnityEngine;
using UnityEngine.SceneManagement; 

public class UI_Vitoria : MonoBehaviour
{
    public static UI_Vitoria Instance;
    public GameObject painelVitoria; 

    private void Awake()
    {
        Instance = this;
        
        if(painelVitoria != null) 
            painelVitoria.SetActive(false);
    }

    public void MostrarVitoria()
    {
        Debug.Log("VITÓRIA!");
        
        
        painelVitoria.SetActive(true);

       
        Time.timeScale = 0f; 
    }

  
    public void VoltarMenu()
    {
        Time.timeScale = 1f; // Despausa antes de sair
        SceneManager.LoadScene("MainMenu");
    }
}