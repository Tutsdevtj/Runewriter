using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public int runaVerde = 0;
    public int runaAzul = 0;
    public string runeColor = ""; 

    // NOVO: Guarda onde o player deve renascer
    public Vector3 ultimoCheckpoint; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            ultimoCheckpoint = player.transform.position;
        }
    }
}