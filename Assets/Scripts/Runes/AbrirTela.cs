using UnityEngine;

public class AbrirTela : MonoBehaviour
{
    public GameObject tela;

    public void Abrir()
    {
        tela.SetActive(true);
    }

    public void Fechar()
    {
        tela.SetActive(false);
    }
}
