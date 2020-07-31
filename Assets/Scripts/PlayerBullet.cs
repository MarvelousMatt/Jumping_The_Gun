using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    float explosionRadius;

    float explosionForce;

    bool explode;

    //Alters the bullet characteristics through the firing entity
    //Essentially a constructor for bullets to get around the limitations of monobehaviour construction
    public void SetCharacteristics(float eSpeed, float eExplosionRadius, float eExplosionForce, bool eExplode)
    {
        speed = eSpeed;
        explosionRadius = eExplosionRadius;
        explosionForce = eExplosionForce;
        explode = eExplode;

        GetComponent<Rigidbody>().AddForce(transform.up * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] rbHits = Physics.OverlapSphere(transform.position, explosionRadius);

        // Loops through the collider array and adds force to each of them.
        //Primarily used for the player, but possibly props too?

        for (int i = 0; i < rbHits.Length; i++)
        {
            if (rbHits[i].gameObject.GetComponent<Rigidbody>() && rbHits[i].gameObject.CompareTag("Player"))
            {
                if(explode)
                    rbHits[i].attachedRigidbody.AddForce((rbHits[i].gameObject.transform.position - transform.position).normalized * explosionForce);
                else
                    rbHits[i].attachedRigidbody.AddForce((transform.position - rbHits[i].gameObject.transform.position).normalized * explosionForce);
            }
                
        }

        Debug.Log("Hit: " + collision.gameObject.name);

        Destroy(gameObject);
    }


}
