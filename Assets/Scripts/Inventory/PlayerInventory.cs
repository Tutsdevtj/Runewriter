using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public int runaVerde;
    public int runaAzul;

    private void Awake()
    {
        Instance = this;
    }
}
