using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{
    private Transform player;

    void Update()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
            return;
        }

        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
    }
}
