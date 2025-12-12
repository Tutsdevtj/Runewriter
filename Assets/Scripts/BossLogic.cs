using UnityEngine;

public class BossLogic : MonoBehaviour
{
    // Arraste o script de vida do Boss para cá no Inspector
    public Entity_Health vidaDoBoss; 

    private bool jaMorreu = false;

    void Update()
    {
        // Se a gente esqueceu de arrastar, tenta pegar automático
        if (vidaDoBoss == null) 
            vidaDoBoss = GetComponent<Entity_Health>();

        // LÓGICA: Se a vida for menor ou igual a zero E ainda não ativamos a vitória
        // (Supondo que sua variável de vida se chame 'currentHealth' ou apenas 'health')
        // Você vai precisar checar qual o nome da variável pública no seu Entity_Health!
        
        /* ATENÇÃO: Abaixo eu assumo que você tem um método ou variável pública pra ver a vida.
           Se não tiver, veja a "Opção B" abaixo.
        */
        
        // Exemplo hipotético (ajuste conforme seu script de vida):
        // if (vidaDoBoss.currentHealth <= 0 && !jaMorreu)
        // {
        //     jaMorreu = true;
        //     UI_Vitoria.Instance.MostrarVitoria();
        // }
    }
    
    // --- OPÇÃO B (Mais Fácil se o Boss é Destruído) ---
    // Se o seu Entity_Health usa "Destroy(gameObject)", use este método:
    
    private void OnDestroy()
    {
        // Verifica se o jogo está rodando (pra não dar vitória quando você fecha o jogo)
        if (gameObject.scene.isLoaded) 
        {
            // Verifica se a tela de vitória existe
            if (UI_Vitoria.Instance != null)
            {
                UI_Vitoria.Instance.MostrarVitoria();
            }
        }
    }
}