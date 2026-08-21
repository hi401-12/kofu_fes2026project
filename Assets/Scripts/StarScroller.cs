using UnityEngine;

public class StarScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float resetY = -10f;
    public float resetHeight = 20f;

    void Update()
    {
        transform.Translate(
            Vector3.down * scrollSpeed * Time.deltaTime
        );

        if (transform.position.y <= resetY)
        {
            transform.position += Vector3.up * resetHeight;
        }
    }
}