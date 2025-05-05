using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    [SerializeField] private float stopingDistance;
    [SerializeField] private float retreatDistance;

    private float timeBtwShoots;
    [SerializeField] float startTimeBtwShoot;

    public GameObject projecttile;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShoots = startTimeBtwShoot;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speedEnemy * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            // stop moving
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speedEnemy * Time.deltaTime);
        }
    
        if (timeBtwShoots <= 0)
        {
            Instantiate(projecttile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoot;
            
        } else {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
