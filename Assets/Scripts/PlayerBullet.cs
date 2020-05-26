using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;

    public float explosionRadius;

    public float explosionForce;

    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] rbHits = Physics.OverlapSphere(transform.position, explosionRadius);

        // Loops through the collider array and adds force to each of them.
        //Primarily used for the player, but possibly props too?

        for (int i = 0; i < rbHits.Length; i++)
        {
            if (rbHits[i].gameObject.GetComponent<Rigidbody>())
                rbHits[i].attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        Debug.Log("Hit: " + collision.gameObject.name);

        Destroy(gameObject);
    }


}
