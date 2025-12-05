using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static Vector2 nextSpawn;

    void Start()
    {
        if (nextSpawn != Vector2.zero)
            transform.position = nextSpawn;
    }
}
