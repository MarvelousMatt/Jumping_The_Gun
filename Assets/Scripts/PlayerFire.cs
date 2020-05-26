using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    public GameObject firePointForward;

    public GameObject firePointBackward;


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

    void Fire(bool fireForward)
    {
        Quaternion bulletRotation;
        Vector3 bulletFirePos;

        //Possibly cut this statement later for efficiency
        if (fireForward)
        {
            bulletRotation = firePointForward.transform.rotation;
            bulletFirePos = firePointForward.transform.position;
        }
        else
        {
            bulletRotation = firePointBackward.transform.rotation;
            bulletFirePos = firePointBackward.transform.position;
        }

        Instantiate(bulletPrefab, bulletFirePos , bulletRotation);
    }

}
