using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public float projectileSpeed;
    private Vector3 target;
    private Vector3 playerPosition;
    private Quaternion playerQuarternion;
    public float numFireballs;

    public Text numberFireballs;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && numFireballs > 0)
        {
            var parent = GameObject.FindGameObjectWithTag("Projectile");
            GameObject fireball = Instantiate(projectile, player.transform.position, Quaternion.identity, parent.transform);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = projectileSpeed * transform.forward;
            numFireballs--;

            numberFireballs.text = numFireballs.ToString("");
        }
    }
}
