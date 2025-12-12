using UnityEngine;
using TMPro;

public class UI_RuneColector : MonoBehaviour
{
    public static UI_RuneColector Instance;

    public TextMeshProUGUI txtVerde;
    public TextMeshProUGUI txtAzul;

    private void Awake()
    {
        Instance = this;
    }

    public void AtualizarUI()
    {
        if (GameState.Instance == null)
        {
          
            return;
        }

        txtVerde.text = "x" + GameState.Instance.runaVerde;
        txtAzul.text = "x" + GameState.Instance.runaAzul;
    }
}