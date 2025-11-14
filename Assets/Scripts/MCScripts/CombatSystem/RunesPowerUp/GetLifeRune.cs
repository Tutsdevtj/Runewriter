using UnityEngine;

public class GetLifeRune : MonoBehaviour
{
    
    [SerializeField] private GameObject lifeRuneTest;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Life Rune Collected");
            HeartLogic heartLogic = other.GetComponent<HeartLogic>();
            if(heartLogic != null)
            {
                heartLogic.vidaMaxima += 1;
            }
            lifeRuneTest.SetActive(false);
        }
    }

}
