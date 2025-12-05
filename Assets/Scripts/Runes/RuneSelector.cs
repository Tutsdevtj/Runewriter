using UnityEngine;
using UnityEngine.UI;

public class RuneSelector : MonoBehaviour
{
    public Image slot1;
    public Image slot2;

    public Sprite verdeSprite;
    public Sprite azulSprite;

    private string corSelecionada = ""; // "", "verde", "azul"

    public void SelecionarVerde()
    {
        Selecionar("verde");
    }

    public void SelecionarAzul()
    {
        Selecionar("azul");
    }

    private void Selecionar(string cor)
    {
        // Se ainda não escolheu nenhuma cor, define a cor da rodada
        if (corSelecionada == "")
        {
            corSelecionada = cor;
        }

        // Bloqueia se tentar selecionar uma cor diferente da primeira
        if (cor != corSelecionada)
        {
            Debug.Log("Só é permitido usar duas runas da mesma cor!");
            return;
        }

        // Preenche os slots
        if (slot1.sprite == null)
        {
            slot1.sprite = (cor == "verde") ? verdeSprite : azulSprite;
        }
        else if (slot2.sprite == null)
        {
            slot2.sprite = (cor == "verde") ? verdeSprite : azulSprite;
        }
        else
        {
            Debug.Log("Dois slots já foram preenchidos!");
        }
    }

    // Caso você queira resetar depois
    public void Resetar()
    {
        slot1.sprite = null;
        slot2.sprite = null;
        corSelecionada = "";
    }
}
