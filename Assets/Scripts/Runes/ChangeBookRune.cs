using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

     
        SceneManager.LoadScene("Kz_Swamp");  
    }

    public void SelecionarAzul()
    {
        bookImage.sprite = livroAzul;

        Destroy(runeSelector);
        Destroy(runeSelectorwindow);

       
        SceneManager.LoadScene("Kz_Cave");  
    }

    public void Resetar()
    {
        bookImage.sprite = livroBase;
    }
}
