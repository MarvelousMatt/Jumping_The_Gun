using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * speed);
    }
}
