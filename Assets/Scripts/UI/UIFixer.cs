using UnityEngine;

public class UIFixer : MonoBehaviour
{
    private Vector3 initialScale;

    void Awake()
    {

        initialScale = transform.localScale;
    }

    void LateUpdate()
    {

        if (transform.parent != null)
        {
            float parentX = transform.parent.localScale.x;

         
            float newX = (parentX < 0) ? -initialScale.x : initialScale.x;

            transform.localScale = new Vector3(newX, initialScale.y, initialScale.z);
        }
    }
}