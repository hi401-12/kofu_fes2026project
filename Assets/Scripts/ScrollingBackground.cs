using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 2f;
    public float resetY = -20f;
    public float moveY = 40f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= resetY)
        {
            transform.position += Vector3.up * moveY;
        }
    }
}