using UnityEngine;
using UnityEngine.UI;

public class ChangeBookRune : MonoBehaviour
{
    public Image bookImage;

    public Sprite livroBase;
    public Sprite livroVerde;
    public Sprite livroAzul;
    [SerializeField] public GameObject runeSelector;
    [SerializeField] public GameObject runeSelectorwindow;
    public void SelecionarVerde()
    {
        bookImage.sprite = livroVerde;
        Destroy(runeSelector);
        Destroy(runeSelectorwindow);
    }

    public void SelecionarAzul()
    {
        bookImage.sprite = livroAzul;
        Destroy(runeSelector);
    }

    public void Resetar()
    {
        bookImage.sprite = livroBase;
    }
}
