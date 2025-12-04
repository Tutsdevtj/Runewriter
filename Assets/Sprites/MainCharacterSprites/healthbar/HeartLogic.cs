using UnityEngine;
using UnityEngine.UI;
public class HeartLogic : MonoBehaviour
{

    public int vida;
    public int vidaMaxima = 4;

    public Image[] coracao;
    public Sprite coracaoCheio;
    public Sprite coracaoVazio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthLogic();
    }
    
    void healthLogic()
    {
        
        for (int i = 0; i < coracao.Length; i++)
        {
            if(vida > vidaMaxima)
            {
                vida = vidaMaxima;
            }

            if (i < vida)
            {
                coracao[i].sprite = coracaoCheio;
            }
            else
            {
                coracao[i].sprite = coracaoVazio;
            }

            if (i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }

    }
}
