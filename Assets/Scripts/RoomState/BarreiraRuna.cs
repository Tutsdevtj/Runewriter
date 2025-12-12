using UnityEngine;

public class BarreiraRuna : MonoBehaviour
{
    void Update()
    {
        if (GameState.Instance == null) return;

      
        bool temRunaVerde = GameState.Instance.runaVerde >= 1;
        bool temRunaAzul = GameState.Instance.runaAzul >= 1;

        if (temRunaVerde && temRunaAzul)
        {
            AbrirPassagem();
        }
    }

    void AbrirPassagem()
    {

        Destroy(gameObject);
    }
}