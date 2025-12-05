using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

}

