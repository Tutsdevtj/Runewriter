using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("Kz_Dungeon");
    }

    public void restartGame()
    {

    }
    
    public void backToMenu()
    {
        Debug.Log("Teste");
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}