using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionVFX;

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Fireball Exploded");

    //    Destroy(gameObject);
    //    Instantiate(explosionVFX, transform.position, transform.rotation);
    //}

    public GameObject Explosion()
    {
        var parent = GameObject.FindGameObjectWithTag("Explosions");
        return Instantiate(explosionVFX, transform.position, transform.rotation, parent.transform);
    }
}
