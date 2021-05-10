using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private float speed = 10;
    private float maxHeight = 16f;
    private float minHeight = 4f;
    public Vector3 position;
    private bool upDown = false;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-130.0f, 104.0f), 0f, UnityEngine.Random.Range(-67.0f, 131.0f));

        position = transform.position;
        gameObject.SetActive(true);

        // var collectible = GameObject.FindGameObjectWithTag("CollectibleFireball");
    }

    // Update is called once per frame
    void Update()
    {
        if (position.y > maxHeight)
        {
            // position = position + Vector3.down * speed * Time.deltaTime;
            upDown = true;
        }
        else if (position.y < minHeight)
        {
            // position = position + Vector3.up * speed * Time.deltaTime;
            upDown = false;
        }

        if (upDown)
        {
            position = position + Vector3.down * speed * Time.deltaTime;
        }
        else
        {
            position = position + Vector3.up * speed * Time.deltaTime;
        }

        transform.position = position;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Fireball on collision");
        if (collision.gameObject.tag == "Player")
        {
            var fireballspawner = GameObject.FindGameObjectWithTag("fireballspawner").GetComponent<FireballSpawn>();
            isAlive = false;
            gameObject.SetActive(false);
            var currentFireballCount = Int16.Parse(fireballspawner.numberFireballs.text);
            currentFireballCount += 5;
            fireballspawner.numFireballs += 5;
            fireballspawner.numberFireballs.text = currentFireballCount.ToString();
        }
    }
}
