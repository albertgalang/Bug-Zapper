using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballEventHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        GetComponent<Projectile>().Explosion();

        if (collision.gameObject.tag == "EnemyEntity")
        {
            var anim = collision.gameObject.GetComponentInChildren<Animator>();
            anim.Play("die");
            collision.gameObject.GetComponent<Enemy>().isDead = true;
            collision.gameObject.GetComponent<Enemy>().Velocity = Vector3.zero;
            collision.gameObject.GetComponent<Enemy>().Speed = 0f;
            collision.gameObject.GetComponent<Enemy>().DesiredSpeed = 0f;
        }
    }
}
