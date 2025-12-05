using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public string runeColor = ""; // "", "verde", "azul"

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 👈 AQUI!
        }
        else
        {
            Destroy(gameObject); // Evita duplicados ao trocar de cenas
        }
    }
}
