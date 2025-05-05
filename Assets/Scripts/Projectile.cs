using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject gameObjectProjectile;

    private Transform player;
    private Vector2 target;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
            Destroy(gameObjectProjectile, 3f);
        //}
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }*/
}
