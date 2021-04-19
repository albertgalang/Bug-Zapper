using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Vector3 position;
    public GameObject gamePiece;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            position.z += 25 * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            position.z -= 25 * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            position.x -= 25 * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            position.x += 25 * Time.deltaTime;

        
    }
}
