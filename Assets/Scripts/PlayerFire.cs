using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    public GameObject firePoint;

    public float speed;

    public float explosionRadius;

    public float implosionRadius;

    public float explosionForce;

    public float implosionForce;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire(true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Fire(false);
        }
    }

    void Fire(bool explode)
    {
        //Fancy visuals and reloading here later
        PlayerBullet bullet  = Instantiate(bulletPrefab, firePoint.transform.position , firePoint.transform.rotation).GetComponent<PlayerBullet>();

        bullet.SetCharacteristics(speed, explosionRadius, explosionForce, explode);

        
    }

}
