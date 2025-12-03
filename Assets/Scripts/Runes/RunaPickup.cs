using UnityEngine;

public class RunaPickup : MonoBehaviour
{
    public RunaTipo tipo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (tipo == RunaTipo.Verde)
                PlayerInventory.Instance.runaVerde++;

            if (tipo == RunaTipo.Azul)
                PlayerInventory.Instance.runaAzul++;

            UI_RuneColector.Instance.AtualizarUI();

            Destroy(gameObject);
        }
    }
}
