using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float x;
    public float y;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Collision Happened");
            other.transform.position = new Vector2(x, y);
        }
    }
}
