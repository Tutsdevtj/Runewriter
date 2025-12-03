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
        txtVerde.text = "x" + PlayerInventory.Instance.runaVerde;
        txtAzul.text = "x" + PlayerInventory.Instance.runaAzul;
    }
}
