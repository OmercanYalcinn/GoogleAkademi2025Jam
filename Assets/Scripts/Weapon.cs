using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    // NORMAL WEAPON
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    // That's how we ganna shoot people
    public void FireBullet(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    // PORTAL GUN
    Camera cam;
    public GameObject portlaPrefab;
    // That's how we ganna open portal
    public void FirePortal(){
        GameObject portal = Instantiate(portlaPrefab, firePoint.position, firePoint.rotation);
        Destroy(portal, 5f);
    }

    void Start()
    {
        cam = Camera.main;
    }

    
}
