using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Cena para entrar")]
    public string cenaDestino;

    [Header("Spawn quando entrar nesta cena")]
    public Vector2 posicaoSpawn;

    [Header("Spawns quando SAIR da RuneRoom")]
    public Vector2 spawnDungeon;
    public Vector2 spawnPantano;
    public Vector2 spawnCaverna;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        string cenaAtual = SceneManager.GetActiveScene().name;

       
        if (cenaDestino == "Runes_Room")
        {
            SceneManager.LoadScene("Runes_Room");
            PlayerSpawn.nextSpawn = posicaoSpawn;
            return;
        }

        
        if (cenaAtual == "Runes_Room")
        {
            if (GameState.Instance.runeColor == "")
            {
                SceneManager.LoadScene("Kz_Dungeon");
                PlayerSpawn.nextSpawn = spawnDungeon;
            }
            else if (GameState.Instance.runeColor == "verde")
            {
                SceneManager.LoadScene("Kz_Swamp");
                PlayerSpawn.nextSpawn = spawnPantano;
            }
            else if (GameState.Instance.runeColor == "azul")
            {
                SceneManager.LoadScene("Kz_Cave");
                PlayerSpawn.nextSpawn = spawnCaverna;
            }

            return;
        }

     
        SceneManager.LoadScene(cenaDestino);
        PlayerSpawn.nextSpawn = posicaoSpawn;
    }
}
